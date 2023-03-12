using ChatWidget.API.Agents;
using ChatWidget.API.Providers;
using ChatWidget.API.Channels.WebChat;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChatWidget.API.Channels.Telegram;
using ChatWidget.API.Channels.WebSocket;
using ChatWidget.API.Agents.HumanAgent;
using ChatWidget.API.Utils;
using ChatWidget.API.Agents.MyChatBot;
using ChatWidget.API.Shared.Socket;
using ChatWidget.API.Controllers;

namespace ChatWidget.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            JwtAuthenticationRegistrar.Register(services);
            services.AddHttpContextAccessor();
            services.AddControllers();
            services.AddSignalR();
            services.AddScoped<Config>();
            services.AddScoped<ChatBot>();
            services.AddScoped<ITokenProvider, TokenProvider>();
            services.AddScoped<WebChatChannel>();
            services.AddScoped<WebSocketChannel>();
            services.AddScoped<TelegramChannel>();
            services.AddScoped<MyChatBotAgent>();
            services.AddScoped<HumanAgent>();
            services.AddScoped<IProxyHubContext, ProxyHubContext>();
            services.AddSingleton<IUserIdProvider, CustomUserIdProvider>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true) // allow any origin
                .AllowCredentials()); // allow credentials

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<WebSocketChatHub>("/chathub");
                endpoints.MapControllers();
            });
        }
    }
}
