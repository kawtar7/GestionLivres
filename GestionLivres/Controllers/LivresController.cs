using GestionLivres.Models;
using Microsoft.AspNetCore.Mvc;

namespace GestionLivres.Controllers
{
    public class LivresController : Controller
    {
        private static List<Livre> livres = new List<Livre>
        {
            new Livre{ISBN=1,Titre="book1",Auteur="auteur1",DateEdition =new DateOnly(2001,1,1)  },
            new Livre{ISBN=2,Titre="book2",Auteur="auteur2",DateEdition =new DateOnly(2001,1,1) },
            new Livre{ISBN=3,Titre="book3",Auteur="auteur3",DateEdition =new DateOnly(2001,1,1) },
            new Livre{ISBN=4,Titre="book4",Auteur="auteur4",DateEdition =new DateOnly(2001,1,1) }
        };
        public IActionResult Index()
        {
            ViewBag.Livres = livres;
            return View(livres);
        }
        public ActionResult Ajouter()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Ajouter(Livre livre)
        {
            livres.Add(livre);
            return RedirectToAction("Index");
        }
       
        public ActionResult Modifier(int ISBN)
        {
            // Trouver le livre par son ID
            var livre = livres.Find(lv => lv.ISBN == ISBN);
            return View(livre);
        }
        [HttpPost]
        public ActionResult Modifier(Livre livre)
        {
            var L = livres.Find(lv => lv.ISBN == livre.ISBN);
            if (L != null)
            {
                L.Titre = livre.Titre;
                L.Auteur = livre.Auteur;
                L.DateEdition = livre.DateEdition;
                L.Resume = livre.Resume;
            }

            return RedirectToAction("Index");
        }
        public ActionResult Supprimer(int ISBN)
        {
            // Trouver le livre par son ID
            Livre livre = livres.FirstOrDefault(l => l.ISBN == ISBN);
            livres.Remove(livre);
            return RedirectToAction("Index");


        }

        // POST: Livres/Supprimer/5
        //[HttpPost, ActionName("Supprimer")]
        //public ActionResult ConfirmerSuppression(int id)
        //{
        //    // Supprimer le livre de la liste simulée
        //    Livre livre = livres.FirstOrDefault(l => l.Id == id);
        //    livres.Remove(livre);

        //    return RedirectToAction("Index");
        //}
    }
}
