using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TP01Module05.Models;

namespace TP01Module05.Controllers
{
    public class ChatController : Controller
    {
        private static List<Chat> chats = Chat.GetMeuteDeChats();

        // GET: Chat
        public ActionResult Index()
        {
            return View(chats);
        }

        // GET: Chat/Details/5
        public ActionResult Details(int id)
        {
            Chat chat = getChatById(id);
            if(chat == null)
            {
                return RedirectToAction("Index");
            }
            return View(chat);
        }

        // GET: Chat/Delete/5
        public ActionResult Delete(int id)
        {
            Chat chat = getChatById(id);
            if (chat != null)
            {
                return View(chat);
            }

            return RedirectToAction("Index");
        }

        // POST: Chat/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                Chat chat = getChatById(id);
                if (chat != null)
                {
                    chats.Remove(chat);
                }
            }
            catch
            {
                return View();
            }

            return RedirectToAction("Index");
        }


        // METHODES PRIVEES
        private Chat getChatById(int id)
        {
            var chat = chats.FirstOrDefault(c => c.Id == id);
            return chat;
        }
    }
}
