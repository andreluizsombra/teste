using appservico.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace appservico.Controllers
{
    public class ServicoController : Controller
    {
        //
        // GET: /Servico/

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public string Usuario()
        {
            return "Andre Sombra";
        }

        [HttpGet]
        public JsonResult ListaEmails()
        {
             string cnx = "data source=sql02.hstbr.net;initial catalog=sgedb;user id=sgedb;password=a1n2d3r4e5;";
            var cnsql = new SqlConnection(cnx);
            cnsql.Open();
            //string sqltxt = string.Format("select USU_EMAIL from usuarios where USU_ID={0}", cod);
            string sqltxt = "select USU_ID,USU_EMAIL from usuarios";
            var dst = new DataSet();
            var adp = new SqlDataAdapter(sqltxt, cnsql);
            adp.Fill(dst);
            
            var lst = new List<Usuario>();
            if (dst != null)
            {
                foreach(DataRow itm in dst.Tables[0].Rows){
                    lst.Add(new Usuario() { Id=int.Parse(itm[0].ToString()), Email = itm[1].ToString() });
                }
                //email = dst.Tables[0].Rows[0][0].ToString();
            }
            cnsql.Close();
            return Json(lst.ToList(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public string Email()
        {
            string cnx = "data source=sql02.hstbr.net;initial catalog=sgedb;user id=sgedb;password=a1n2d3r4e5;";
            var cnsql = new SqlConnection(cnx);
            cnsql.Open();
            //string sqltxt = string.Format("select USU_EMAIL from usuarios where USU_ID={0}", cod);
            string sqltxt = "select USU_EMAIL from usuarios where USU_ID=1";
            var dst = new DataSet();
            var adp = new SqlDataAdapter(sqltxt, cnsql);
            adp.Fill(dst);
            cnsql.Close();
            string _email = dst.Tables[0].Rows[0][0].ToString();

            if (_email == "") _email = "NAO ENCONTRADO";
            return _email;
        }

        public JsonResult Teste()
        {
            string cnx = "data source=sql02.hstbr.net;initial catalog=sgedb;user id=sgedb;password=a1n2d3r4e5;";
            var cnsql = new SqlConnection(cnx);
            cnsql.Open();
            //string sqltxt = string.Format("select USU_EMAIL from usuarios where USU_ID={0}", cod);
            string sqltxt = "select USU_EMAIL from usuarios";
            var dst = new DataSet();
            var adp = new SqlDataAdapter(sqltxt, cnsql);
            adp.Fill(dst);

            var lst = new List<string>();
            if (dst != null)
            {
                foreach (DataRow itm in dst.Tables[0].Rows)
                {
                    lst.Add(itm[0].ToString());
                }
                //email = dst.Tables[0].Rows[0][0].ToString();
            }
            cnsql.Close();
            return Json(lst.ToList(), JsonRequestBehavior.AllowGet);
        }
        
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Servico/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Servico/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Servico/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
