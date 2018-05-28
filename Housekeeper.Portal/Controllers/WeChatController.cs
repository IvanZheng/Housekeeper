using System.Threading.Tasks;
using Housekeeper.Portal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Senparc.Weixin;
using Senparc.Weixin.MP.AdvancedAPIs;

namespace Housekeeper.Portal.Controllers
{
    [Route("WeChat")]
    public class WeChatController : Controller
    {
        private readonly WeChatApp _weChatApp;

        public WeChatController(IOptions<WeChatApp> weChatApp)
        {
            _weChatApp = weChatApp.Value;
        }

        [HttpGet("Authorize")]
        public async Task<IActionResult> AuthorizeAsync(string code, string redirectUri)
        {
            var weChatUser = await OAuthApi.GetAccessTokenAsync(_weChatApp.AppId,
                                                                _weChatApp.Secret,
                                                                code)
                                           .ConfigureAwait(false);
            if (weChatUser.errcode == ReturnCode.请求成功)
            {
                return Redirect(string.IsNullOrWhiteSpace(redirectUri) ? "~/" : redirectUri);
            }

            return RedirectToAction("Error", "Home");
        }
    }
}