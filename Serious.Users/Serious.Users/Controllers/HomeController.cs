using Serious.Users.AppCode.AESEncryption;
using System;
using System.Text;
using System.Threading;
using System.Web.Mvc;

namespace Serious.Users.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Encrypt(string text)
        {            
            string aesKey256 = Guid.NewGuid().ToString().Replace("-", "");
            Session["Key"] = aesKey256;

            ICrypto cryptor = new AesEncryptor(aesKey256, Constants.AES_IV_256);
            string result = cryptor.Encrypt(text.Replace(" ", "___"));

            return Json(new
            {
                cryptedText = result
            });
        }

        public JsonResult Decrypt(string text)
        {
            string aesKey256 = Session["Key"].ToString();

            ICrypto cryptor = new AesEncryptor(aesKey256, Constants.AES_IV_256);
            string result = cryptor.Decrypt(text);
            Thread.Sleep(5000);
            return Json(new
            {
                cryptedText = result.Replace("___", " ")
            });
        }
    }
}