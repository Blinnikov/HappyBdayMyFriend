﻿using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HappyBirthdayMyFriend.Web.Mvc.Startup))]
namespace HappyBirthdayMyFriend.Web.Mvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
