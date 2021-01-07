using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MedicalOfficeEntities;
using MedicalOfficeEntities.Entities;

 
namespace MedicalOfficeWeb
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        DbContext_MedicalOffice db = new DbContext_MedicalOffice();

        protected void Page_Load(object sender, EventArgs e)
        {

            Refresh();

        }
        public void Refresh()
        {
            gv_patients.DataSource = (from x in db.Patients select x).ToList();
            gv_patients.DataBind();
        }

        protected void gv_patients_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow gvr = gv_patients.SelectedRow;
            Int32 selectedID = Convert.ToInt32(gvr.Cells[0].Text);
            hf_patientID.Value = selectedID.ToString();
            tb_firstname.Text = gvr.Cells[2].Text;
            tb_lastname.Text = gvr.Cells[1].Text;
            tb_address.Text = gvr.Cells[3].Text;
            tb_email.Text = gvr.Cells[4].Text;

        }

        protected void bt_del_Click(object sender, EventArgs e)
        {
            int id = int.Parse(hf_patientID.Value);
            Patient patient = (from p in db.Patients
                where p.PatientId == id
                select p).First();
            db.Patients.Remove(patient);
            db.SaveChanges();
        }

        protected void bt_mod_Click(object sender, EventArgs e)
        {
            Int32 selectedID = Convert.ToInt32(hf_patientID.Value); 

            Patient patient = (from p in db.Patients
                               where p.PatientId == selectedID
                select p).First();
            patient.Lastname = tb_lastname.Text;
            patient.Firstname = tb_firstname.Text;
            patient.Address = tb_address.Text;
            patient.Email = tb_email.Text;
            db.SaveChanges();
        }

        protected void bt_add_Click(object sender, EventArgs e)
        {
            Patient patient = new Patient();
            patient.Lastname = tb_lastname.Text;
            patient.Firstname = tb_firstname.Text;
            patient.Address = tb_address.Text;
            patient.Email = tb_email.Text;
            db.Patients.Add(patient);
            db.SaveChanges();
        }

        protected void bt_search_OnClick(object sender, EventArgs e)
        {
            if(tb_searchID.Text != "")
            {
                int pid = int.Parse(tb_searchID.Text);
                gv_patients.DataSource = (from p in db.Patients
                                          where p.PatientId == pid
                                          select p).ToList();
                gv_patients.DataBind();
            } 
            else if (tb_searchName.Text != "")
            {
                gv_patients.DataSource = (from p in db.Patients
                                          where p.Lastname.Equals(tb_searchName.Text)
                                          select p).ToList();
                gv_patients.DataBind();
            }
            else 
            {
                Response.Write("<script>alert(\"Please enter a search query !\");</script>");
            }

        }
    }
}