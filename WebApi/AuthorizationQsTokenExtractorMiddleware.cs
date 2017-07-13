﻿using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace WebApi
{
    public class AuthorizationQsTokenExtractorMiddleware: OwinMiddleware
    {
        public AuthorizationQsTokenExtractorMiddleware(OwinMiddleware next) : base(next)
        {
        }

        /// <summary>
        /// Extracting the Authorization info from the query string and adding it to the headers.
        /// </summary>
        /// <param name="context">The context</param>
        /// <returns>The task</returns>
        public override async Task Invoke(IOwinContext context)
        {
            var bearerToken = context.Request.Query.Get("access_token");

            if (!string.IsNullOrEmpty(bearerToken))
            {
                string[] authorization = { "Bearer " + bearerToken };
                context.Request.Headers.Add("Authorization", authorization);
            }

            await Next.Invoke(context);
        }
    }
}