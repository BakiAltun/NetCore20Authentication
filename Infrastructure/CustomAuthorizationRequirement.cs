
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
 

namespace NetCore20Auth
{
    public class LoggingAuthorizationHandler: AuthorizationHandler<LoggingAuthorizationRequirement>
    {
        public LoggingAuthorizationHandler()
        {
        }
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, LoggingAuthorizationRequirement requirement)
        {  
            //  context.Succeed(requirement);
          
            return Task.CompletedTask; 
        }
    }
    public class LoggingAuthorizationRequirement : IAuthorizationRequirement  
    {
        public LoggingAuthorizationRequirement()
        {

        } 
    }
}