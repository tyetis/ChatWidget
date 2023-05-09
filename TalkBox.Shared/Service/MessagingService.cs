using TalkBox.Infrastructure.EntityFramework;
using TalkBox.Shared.Agents;
using TalkBox.Shared.Channels;
using TalkBox.Shared.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace TalkBox.Shared.Service
{
    public class MessagingService
    {
        DatabaseService Database { get; set; }
        IServiceProvider ServiceProvider { get; set; }

        public MessagingService(IServiceProvider serviceProvider, DatabaseService database)
        {
            ServiceProvider = serviceProvider;
            Database = database;
        }

        public void OnMessageFromUser(ChannelMessage payload)
        {
            SaveUserMessage(payload);
            var agentInbox = GetAgentInbox(payload.InboxId);
            var agent = GetAgent(Enums.Agents[agentInbox.AgentId]);
            agent.OnMessageFromUser(new AgentUserMessage
            {
                UserId = payload.UserId.ToString(),
                AgentInboxId = agentInbox.AgentInboxId,
                Message = payload.Message
            });
        }

        public void OnMessageFromAgent(AgentMessage payload)
        {
            SaveAgentMessage(payload);
            var user = GetUser(payload.UserId);
            var channel = GetChannel(Enums.Channels[user.ChannelId]);
            channel.OnMessageFromAgent(payload);
        }

        public User CreateUser(Guid inboxId, int channelId)
        {
            using(var db = Database.GetDatabase())
            {
                var newUser = new User
                {
                    InboxId = inboxId,
                    ChannelId = channelId
                };
                db.Users.Add(newUser);
                db.SaveChanges();
                return newUser;
            }
        }

        public User GetOrCreateUserFromChannel(Guid inboxId, int channelId, string channelUserId)
        {
            using (var db = Database.GetDatabase())
            {
                var cu = db.ChannelUsers.Where(n => n.ChannelUserId == channelUserId).Select(n => n.User).FirstOrDefault();
                if(cu == null)
                {
                    var newUser = CreateUser(inboxId, channelId);
                    var newChannelUser = new ChannelUser
                    {
                        ChannelId = channelId,
                        UserId = newUser.Id,
                        ChannelUserId = channelUserId
                    };
                    db.ChannelUsers.Add(newChannelUser);
                    db.SaveChanges();
                    return newUser;
                }
                return cu;
            }
        }

        public ChannelUser GetChannelUser(Guid userId, int channelId)
        {
            using (var db = Database.GetDatabase())
            {
                return db.ChannelUsers.FirstOrDefault(n => n.UserId == userId);
            }
        }

        public ChannelInbox GetInboxFromChannel(string channelInboxId, int channelId)
        {
            using (var db = Database.GetDatabase())
            {
                return db.ChannelInboxes.FirstOrDefault(n => n.ChannelInboxId == channelInboxId && n.ChannelId == channelId);
            }
        }

        private IAgent GetAgent(string userAgentType)
        {
            var type = Type.GetType($"TalkBox.Agents.{userAgentType}");
            return (IAgent)ServiceProvider.GetService(type);
        }

        private IChannel GetChannel(string channelType)
        {
            var type = Type.GetType($"TalkBox.Channels.{channelType}");
            return (IChannel)ServiceProvider.GetService(type);
        }

        private void SaveUserMessage(ChannelMessage payload)
        {
            using (var db = Database.GetDatabase())
            {
                db.Messages.Add(new Message
                {
                    UserId = payload.UserId,
                    Owner = (int)Enums.MessageOwner.User,
                    Type = payload.Message.GetType().Name,
                    Message1 = JsonSerializer.Serialize(payload.Message),
                    SentDate = DateTime.Now
                });
                db.SaveChanges();
            }
        }

        private void SaveAgentMessage(AgentMessage payload)
        {
            using (var db = Database.GetDatabase())
            {
                db.Messages.Add(new Message
                {
                    UserId = payload.UserId,
                    Owner = (int)Enums.MessageOwner.Agent,
                    Type = payload.Message.GetType().Name,
                    Message1 = JsonSerializer.Serialize(payload.Message),
                    SentDate = DateTime.Now
                });
                db.SaveChanges();
            }
        }

        private AgentInbox GetAgentInbox(Guid inboxId)
        {
            using (var db = Database.GetDatabase())
            {
                return db.AgentInboxes.FirstOrDefault(n => n.InboxId == inboxId);
            }
        }

        private User GetUser(Guid userId)
        {
            using (var db = Database.GetDatabase())
            {
                return db.Users.Find(userId);
            }
        }

    }
}
