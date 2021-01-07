using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MedicalOfficeEntities.Entities;

namespace MedicalOfficeWeb
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        DbContext_MedicalOffice db = new DbContext_MedicalOffice();

        protected void Page_Load(object sender, EventArgs e)
        {

            Refresh();
            ddl_patients.Enabled = true;
            lbl_newPatient.Enabled = true;

        }
        public void Refresh()
        {
            gv_visits.DataSource = (from x in db.Visits select x).ToList();
            gv_visits.DataBind();
            
            ddl_patients.DataSource = (from x in db.Patients select x).ToList();
            ddl_patients.DataTextField = "PatientId";
            ddl_patients.DataValueField = "Lastname";
            ddl_patients.DataBind();
        }

        protected void gv_visits_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            Int32 selectedID = Convert.ToInt32(gv_visits.SelectedRow.Cells[0].Text);
            hf_visitID.Value = selectedID.ToString();
            
            Visit selected = (from v in db.Visits
                where v.VisitId == selectedID
                select v).First();
            
            tb_firstname.Text = selected.Patient.Firstname;
            tb_lastname.Text = selected.Patient.Lastname;
            tb_date.Text = selected.Date.ToString();
            tb_record.Text = selected.Record;

            ddl_patients.Enabled = false;
            lbl_newPatient.Enabled = false;
        }

        protected void bt_del_Click(object sender, EventArgs e)
        {
            int id = int.Parse(hf_visitID.Value);
            Visit visit = (from p in db.Visits
                where p.VisitId == id
                select p).First();
            db.Visits.Remove(visit);
            db.SaveChanges();
        }

        protected void bt_mod_Click(object sender, EventArgs e)
        {
            Int32 selectedID = Convert.ToInt32(hf_visitID.Value); 

            Visit visit = (from p in db.Visits
                               where p.VisitId == selectedID
                select p).First();
            visit.Record = tb_record.Text;
            db.SaveChanges();
        }

        protected void bt_add_Click(object sender, EventArgs e)
        {
            Visit visit = new Visit();
            visit.PatientId = int.Parse(ddl_patients.SelectedValue);
            visit.Record = tb_record.Text;
            visit.Date = new DateTime();
            db.Visits.Add(visit);
            db.SaveChanges();
            ddl_patients.Enabled = false;
            lbl_newPatient.Enabled = false;
        }

        protected void bt_search_OnClick(object sender, EventArgs e)
        {
            if(tb_searchID.Text != "")
            {
                int pid = int.Parse(tb_searchID.Text);
                gv_visits.DataSource = (from p in db.Visits
                                          where p.VisitId == pid
                                          select p).ToList();
                gv_visits.DataBind();
            } 
            else if (tb_searchName.Text != "")
            {
                gv_visits.DataSource = (from v in db.Visits
                                          where v.Patient.Lastname.Equals(tb_searchName.Text)
                                          select v).ToList();
                gv_visits.DataBind();
            }
            else 
            {
                Response.Write("<script>alert(\"Please enter a search query !\");</script>");
            }

        }
    }
}