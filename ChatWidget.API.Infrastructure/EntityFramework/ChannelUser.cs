﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace ChatWidget.API.Infrastructure.EntityFramework
{
    public partial class ChannelUser
    {
        public int Id { get; set; }
        public int ChannelId { get; set; }
        public Guid UserId { get; set; }
        public string ChannelUserId { get; set; }

        public virtual User User { get; set; }
    }
}