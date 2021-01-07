using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MedicalOfficeEntities;
using MedicalOfficeEntities.Entities;

namespace MedicalOfficeWeb
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        DbContext_MedicalOffice db = new DbContext_MedicalOffice();

        protected void Page_Load(object sender, EventArgs e)
        {

            Refresh();

        }
        public void Refresh()
        {
            gv_appointments.DataSource = (from x in db.Appointments select x).ToList();
            gv_appointments.DataBind();
            
            ddl_patients.DataSource = (from x in db.Patients select x).ToList();
            ddl_patients.DataTextField = "PatientId";
            ddl_patients.DataValueField = "Lastname";
            ddl_patients.DataBind();
        }

        protected void gv_appointments_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            Int32 selectedID = Convert.ToInt32(gv_appointments.SelectedRow.Cells[0].Text);
            hf_appointmentID.Value = selectedID.ToString();

            Appointment selected = (from a in db.Appointments
                where a.AppointmentId == selectedID
                select a).First();
            
            tb_firstname.Text = selected.Patient.Firstname;
            tb_lastname.Text = selected.Patient.Lastname;
            tb_address.Text = selected.Patient.Address;
            tb_email.Text = selected.Patient.Email;

            tb_date.Text = selected.DateTime.ToString();
            ddl_status.SelectedValue = selected.Status;
            ddl_patients.SelectedValue = selected.Patient.PatientId.ToString();

        }

        protected void bt_del_Click(object sender, EventArgs e)
        {
            int id = int.Parse(hf_appointmentID.Value);
            Appointment appointment = (from p in db.Appointments
                where p.AppointmentId == id
                select p).First();
            db.Appointments.Remove(appointment);
            db.SaveChanges();
        }

        protected void bt_mod_Click(object sender, EventArgs e)
        {
            Int32 selectedID = Convert.ToInt32(hf_appointmentID.Value); 

            Appointment appointment = (from p in db.Appointments
                               where p.AppointmentId == selectedID
                select p).First();
            
            appointment.Status= ddl_status.SelectedValue.ToString();
            appointment.DateTime = Convert.ToDateTime(tb_date.Text);
            db.SaveChanges();
        }

        protected void bt_add_Click(object sender, EventArgs e)
        {
            Appointment appointment = new Appointment();
            appointment.DateTime = Convert.ToDateTime(tb_date.Text);
            appointment.Status = "NONE";
            appointment.PatientId = int.Parse(ddl_patients.SelectedValue); 
            db.Appointments.Add(appointment);
            db.SaveChanges();
        }

        protected void bt_search_OnClick(object sender, EventArgs e)
        {
            if(tb_searchStartDate.Text != "")
            {

                DateTime startDate = Convert.ToDateTime(tb_searchStartDate.Text);
                DateTime endDate = Convert.ToDateTime(tb_searchStartDate.Text);

                gv_appointments.DataSource = (from a in db.Appointments
                                          where a.DateTime >= startDate || a.DateTime <= endDate
                                          select a).ToList();
                gv_appointments.DataBind();
            } 
            else if (tb_searchName.Text != "")
            {
                gv_appointments.DataSource = (from p in db.Appointments
                                          where p.Patient.Lastname.Equals(tb_searchName.Text)
                                          select p).ToList();
                gv_appointments.DataBind();
            }
            else 
            {
                Response.Write("<script>alert(\"Please enter a search query !\");</script>");
            }

        }
    }
}