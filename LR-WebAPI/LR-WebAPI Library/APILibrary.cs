using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;

namespace LR_WebAPI
{
    public class APILibrary
    {
        public string hn = string.Empty;
        public string name = string.Empty;
        public string age = string.Empty;
        public string gpal = string.Empty;
        public string edc = string.Empty;
        public string ga = string.Empty;
        public string admit_at = string.Empty;
        public string admit_times = string.Empty;
        public string bed = string.Empty;

        public string anc_at = string.Empty;
        public string anc_times = string.Empty;

        public string lab1 = string.Empty;
        public string lab1_note = string.Empty;
        public string lab2 = string.Empty;
        public string lab2_note = string.Empty;

        public string hct1 = string.Empty;
        public string hct2 = string.Empty;
        public string allergy = string.Empty;
        public string allergy_note = string.Empty;

        public string surgery = string.Empty;

        public string surgery_note = string.Empty;
        public string uc = string.Empty;
        public string uc_note = string.Empty;
        public string risk = string.Empty;
        public string risk_note = string.Empty;
        public string covid_status = string.Empty;

        public int me_id;
        public int bed_id;
        public string datetime = string.Empty;
        public string chief_complaint = string.Empty;
        public string vs = string.Empty;
        public string baby_weight = string.Empty;
        public string baby_weight_twin = string.Empty;
        public string baby_fhs = string.Empty;
        public string baby_fhs_note = string.Empty;
        public string baby_fhs_twin = string.Empty;
        public string baby_fhs_twin_note = string.Empty;
        public string utene = string.Empty;
        public string pv_dilate = string.Empty;
        public string pv_effacement = string.Empty;
        public string pv_membrane = string.Empty;
        public string pv_membrane_note = string.Empty;
        public string pv_station = string.Empty;
        public string pv_present = string.Empty;
        public string pv_present_twin = string.Empty;
        public string plan = string.Empty;
        public string status = string.Empty;
        public string note = string.Empty;
        public string saveas = string.Empty;

        public string endEFW = string.Empty;
        public string endAGPAR = string.Empty;
        public string follow = string.Empty;
        public string delivery = string.Empty;

        public string curZone = string.Empty;
        public string curBed = string.Empty;
        public string toZone = string.Empty;
        public string toBed = string.Empty;

        //private string connectionstr = "server=localhost;user id=expert;password=1kobb@ll;database=lr-db;port=3306;persistsecurityinfo=True;SslMode=Required;maxpoolsize=400;minpoolsize=0;default command timeout=600;charset=utf8;";
        private string connectionstr = "server=localhost;user id=root;password=root;database=lr-db;port=3306;persistsecurityinfo=True;SslMode=Required;maxpoolsize=400;minpoolsize=0;default command timeout=600;charset=utf8;";


        public bool AddNewPatient()
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(connectionstr);

                //-------------------------- SELECT pt_hn FROM tbl_bed ---------------------------------
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                    StringBuilder SQL_SELECT_BED = new StringBuilder();
                    SQL_SELECT_BED.AppendFormat(" SELECT pt_hn FROM tbl_bed WHERE tbl_bed.pt_hn = '{0}' ", hn);

                    MySqlCommand CMD_SELECT_BED = new MySqlCommand(SQL_SELECT_BED.ToString(), conn);
                    MySqlDataReader SELECT_BED_DataReader = CMD_SELECT_BED.ExecuteReader();
                    if (SELECT_BED_DataReader.Read())
                    {
                        if (SELECT_BED_DataReader[0].ToString() == hn)
                        {
                            return false;
                        }
                    }
                    conn.Close();
                }

                //-------------------------- UPDATE tbl_bed ---------------------------------
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                    StringBuilder SQL_UPDATE_BED = new StringBuilder();
                    SQL_UPDATE_BED.AppendFormat(" UPDATE tbl_bed SET pt_hn = '{0}', bed_admit_date = '{1}' WHERE ", hn, datetime);
                    if (admit_at == "Wait")
                    {
                        SQL_UPDATE_BED.AppendFormat("bed_no = {0} AND bed_zone = 'Wait'", bed);
                    }
                    else if (admit_at == "Safe")
                    {
                        SQL_UPDATE_BED.AppendFormat("bed_no = {0} AND bed_zone = 'Safe'", bed);
                    }

                    MySqlCommand CMD_UPDATE_BED = new MySqlCommand(SQL_UPDATE_BED.ToString(), conn);
                    CMD_UPDATE_BED.ExecuteNonQuery();
                    conn.Close();
                }

                //-------------------------- SELECT bed_id FROM tbl_bed ---------------------------------
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                    StringBuilder SQL_SELECT_BED = new StringBuilder();
                    SQL_SELECT_BED.AppendFormat(" SELECT bed_id FROM tbl_bed WHERE tbl_bed.pt_hn = '{0}' ", hn);

                    MySqlCommand CMD_SELECT_BED = new MySqlCommand(SQL_SELECT_BED.ToString(), conn);
                    MySqlDataReader SELECT_BED_DataReader = CMD_SELECT_BED.ExecuteReader();
                    if (SELECT_BED_DataReader.Read())
                    {
                        bed_id = Convert.ToInt32(SELECT_BED_DataReader[0]);
                    }
                    conn.Close();
                }

                //-------------------------- SELECT pt_hn FROM tbl_patient ---------------------------------
                StringBuilder SQL_INSERT_NEW_PATIENT = new StringBuilder();
                StringBuilder SQL_UPDATE_MAIN_EVENT = new StringBuilder();
                SQL_INSERT_NEW_PATIENT.Append("");
                SQL_UPDATE_MAIN_EVENT.Append("");

                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                    StringBuilder SQL_SELECT_HN = new StringBuilder();
                    SQL_SELECT_HN.AppendFormat(" SELECT IFNULL(pt_hn, '') AS pt_hn FROM tbl_patient WHERE tbl_patient.pt_hn = '{0}' ", hn);

                    MySqlCommand CMD_SELECT_HN = new MySqlCommand(SQL_SELECT_HN.ToString(), conn);
                    MySqlDataReader SELECT_HN_DataReader = CMD_SELECT_HN.ExecuteReader();

                    DataTable dt = new DataTable();
                    dt.Load(SELECT_HN_DataReader);

                    if (dt.Rows.Count == 0)
                    {
                        SQL_INSERT_NEW_PATIENT.Append(" INSERT INTO tbl_patient ( ");
                        SQL_INSERT_NEW_PATIENT.Append(" pt_hn ");
                        SQL_INSERT_NEW_PATIENT.Append(" ,pt_name ");
                        SQL_INSERT_NEW_PATIENT.Append(" ,pt_age ");
                        SQL_INSERT_NEW_PATIENT.Append(" ,pt_gpal ");
                        SQL_INSERT_NEW_PATIENT.Append(" ,pt_edc ");
                        SQL_INSERT_NEW_PATIENT.Append(" ,pt_ga ");
                        SQL_INSERT_NEW_PATIENT.Append(" ,pt_admit_at ");
                        SQL_INSERT_NEW_PATIENT.Append(" ,pt_admit_times ");
                        SQL_INSERT_NEW_PATIENT.Append(" ,bed_id ");
                        SQL_INSERT_NEW_PATIENT.Append(" ,pt_lab1 ");
                        SQL_INSERT_NEW_PATIENT.Append(" ,pt_lab1_note ");
                        SQL_INSERT_NEW_PATIENT.Append(" ,pt_lab2 ");
                        SQL_INSERT_NEW_PATIENT.Append(" ,pt_lab2_note ");
                        SQL_INSERT_NEW_PATIENT.Append(" ,pt_hct1 ");
                        SQL_INSERT_NEW_PATIENT.Append(" ,pt_hct2 ");
                        SQL_INSERT_NEW_PATIENT.Append(" ,pt_allergy ");
                        SQL_INSERT_NEW_PATIENT.Append(" ,pt_allergy_note ");
                        SQL_INSERT_NEW_PATIENT.Append(" ,pt_surgery ");
                        SQL_INSERT_NEW_PATIENT.Append(" ,pt_surgery_note ");
                        SQL_INSERT_NEW_PATIENT.Append(" ,pt_uc ");
                        SQL_INSERT_NEW_PATIENT.Append(" ,pt_uc_note ");
                        SQL_INSERT_NEW_PATIENT.Append(" ,pt_risk ");
                        SQL_INSERT_NEW_PATIENT.Append(" ,pt_risk_note ");
                        SQL_INSERT_NEW_PATIENT.Append(" ,pt_covid_status ");
                        SQL_INSERT_NEW_PATIENT.Append(" ) VALUES (");
                        SQL_INSERT_NEW_PATIENT.AppendFormat("'{0}'", hn);
                        SQL_INSERT_NEW_PATIENT.AppendFormat(",'{0}'", name);
                        SQL_INSERT_NEW_PATIENT.AppendFormat(",{0}", age);
                        SQL_INSERT_NEW_PATIENT.AppendFormat(",{0}", gpal);
                        SQL_INSERT_NEW_PATIENT.AppendFormat(",'{0}'", edc);
                        SQL_INSERT_NEW_PATIENT.AppendFormat(",'{0}'", ga);
                        SQL_INSERT_NEW_PATIENT.AppendFormat(",'{0}'", admit_at);
                        SQL_INSERT_NEW_PATIENT.AppendFormat(",{0}", admit_times);
                        SQL_INSERT_NEW_PATIENT.AppendFormat(",{0}", bed_id);
                        SQL_INSERT_NEW_PATIENT.AppendFormat(",{0}", lab1);
                        SQL_INSERT_NEW_PATIENT.AppendFormat(",'{0}'", lab1_note);
                        SQL_INSERT_NEW_PATIENT.AppendFormat(",{0}", lab2);
                        SQL_INSERT_NEW_PATIENT.AppendFormat(",'{0}'", lab2_note);
                        SQL_INSERT_NEW_PATIENT.AppendFormat(",{0}", hct1);
                        SQL_INSERT_NEW_PATIENT.AppendFormat(",{0}", hct2);
                        SQL_INSERT_NEW_PATIENT.AppendFormat(",{0}", allergy);
                        SQL_INSERT_NEW_PATIENT.AppendFormat(",'{0}'", allergy_note);
                        SQL_INSERT_NEW_PATIENT.AppendFormat(",{0}", surgery);
                        SQL_INSERT_NEW_PATIENT.AppendFormat(",'{0}'", surgery_note);
                        SQL_INSERT_NEW_PATIENT.AppendFormat(",{0}", uc);
                        SQL_INSERT_NEW_PATIENT.AppendFormat(",'{0}'", uc_note);
                        SQL_INSERT_NEW_PATIENT.AppendFormat(",{0}", risk);
                        SQL_INSERT_NEW_PATIENT.AppendFormat(",'{0}'", risk_note);
                        SQL_INSERT_NEW_PATIENT.AppendFormat(",'{0}'", covid_status);
                        SQL_INSERT_NEW_PATIENT.Append(" );");
                    }
                    else
                    {
                        SQL_UPDATE_MAIN_EVENT.Append(" UPDATE tbl_patient ");
                        SQL_UPDATE_MAIN_EVENT.AppendFormat(" SET pt_age = {0} ", age);
                        SQL_UPDATE_MAIN_EVENT.AppendFormat(" , pt_gpal = {0} ", gpal);
                        SQL_UPDATE_MAIN_EVENT.AppendFormat(" , pt_edc = '{0}' ", edc);
                        SQL_UPDATE_MAIN_EVENT.AppendFormat(" , pt_ga = '{0}' ", ga);
                        SQL_UPDATE_MAIN_EVENT.AppendFormat(" , pt_admit_at = '{0}' ", admit_at);
                        SQL_UPDATE_MAIN_EVENT.AppendFormat(" , pt_admit_times = {0} ", admit_times);
                        SQL_UPDATE_MAIN_EVENT.AppendFormat(" , bed_id = {0} ", bed_id);
                        SQL_UPDATE_MAIN_EVENT.AppendFormat(" , pt_lab1 = {0} ", lab1);
                        SQL_UPDATE_MAIN_EVENT.AppendFormat(" , pt_lab1_note = '{0}' ", lab1_note);
                        SQL_UPDATE_MAIN_EVENT.AppendFormat(" , pt_lab2 = {0} ", lab2);
                        SQL_UPDATE_MAIN_EVENT.AppendFormat(" , pt_lab2_note = '{0}' ", lab2_note);
                        SQL_UPDATE_MAIN_EVENT.AppendFormat(" , pt_hct1 = {0} ", hct1);
                        SQL_UPDATE_MAIN_EVENT.AppendFormat(" , pt_hct2 = {0} ", hct2);
                        SQL_UPDATE_MAIN_EVENT.AppendFormat(" , pt_allergy = {0} ", allergy);
                        SQL_UPDATE_MAIN_EVENT.AppendFormat(" , pt_allergy_note = '{0}' ", allergy_note);
                        SQL_UPDATE_MAIN_EVENT.AppendFormat(" , pt_surgery = {0} ", surgery);
                        SQL_UPDATE_MAIN_EVENT.AppendFormat(" , pt_surgery_note = '{0}' ", surgery_note);
                        SQL_UPDATE_MAIN_EVENT.AppendFormat(" , pt_uc = {0} ", uc);
                        SQL_UPDATE_MAIN_EVENT.AppendFormat(" , pt_uc_note = '{0}' ", uc_note);
                        SQL_UPDATE_MAIN_EVENT.AppendFormat(" , pt_risk = {0} ", risk);
                        SQL_UPDATE_MAIN_EVENT.AppendFormat(" , pt_risk_note = '{0}' ", risk_note);
                        SQL_UPDATE_MAIN_EVENT.AppendFormat(" , pt_covid_status = '{0}' ", covid_status);
                        SQL_UPDATE_MAIN_EVENT.AppendFormat(" WHERE pt_hn = '{0}' ", hn);
                    }
                    conn.Close();
                }

                //-------------------------- INSERT or UPDATE tbl_patient ---------------------------------
                if(SQL_INSERT_NEW_PATIENT.ToString() != "")
                {
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                        MySqlCommand CMD_INSERT_NEW_PATIENT = new MySqlCommand(SQL_INSERT_NEW_PATIENT.ToString(), conn);
                        CMD_INSERT_NEW_PATIENT.ExecuteNonQuery();
                        conn.Close();
                    }
                }
                else
                {
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                        MySqlCommand CMD_UPDATE_NEW_PATIENT = new MySqlCommand(SQL_UPDATE_MAIN_EVENT.ToString(), conn);
                        CMD_UPDATE_NEW_PATIENT.ExecuteNonQuery();
                        conn.Close();
                    }
                }

                ////-------------------------- INSERT tbl_main_event ---------------------------------
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                    StringBuilder SQL_INSERT_MAIN_EVENT = new StringBuilder();
                    SQL_INSERT_MAIN_EVENT.Append(" INSERT INTO tbl_main_event ( ");
                    SQL_INSERT_MAIN_EVENT.Append(" pt_hn ");
                    SQL_INSERT_MAIN_EVENT.Append(" ,me_datetime ");
                    SQL_INSERT_MAIN_EVENT.Append(" ,me_chief_complaint ");
                    SQL_INSERT_MAIN_EVENT.Append(" ,me_vs ");
                    SQL_INSERT_MAIN_EVENT.Append(" ,me_baby_weight ");
                    SQL_INSERT_MAIN_EVENT.Append(" ,me_baby_weight_twin ");
                    SQL_INSERT_MAIN_EVENT.Append(" ,me_baby_fhs ");
                    SQL_INSERT_MAIN_EVENT.Append(" ,me_baby_fhs_note ");
                    SQL_INSERT_MAIN_EVENT.Append(" ,me_baby_fhs_twin ");
                    SQL_INSERT_MAIN_EVENT.Append(" ,me_baby_fhs_twin_note ");
                    SQL_INSERT_MAIN_EVENT.Append(" ,me_utene ");
                    SQL_INSERT_MAIN_EVENT.Append(" ,me_pv_dilate ");
                    SQL_INSERT_MAIN_EVENT.Append(" ,me_pv_effacement ");
                    SQL_INSERT_MAIN_EVENT.Append(" ,me_pv_membrane ");
                    SQL_INSERT_MAIN_EVENT.Append(" ,me_pv_membrane_note ");
                    SQL_INSERT_MAIN_EVENT.Append(" ,me_pv_station ");
                    SQL_INSERT_MAIN_EVENT.Append(" ,me_pv_present ");
                    SQL_INSERT_MAIN_EVENT.Append(" ,me_pv_present_twin ");
                    SQL_INSERT_MAIN_EVENT.Append(" ,me_plan ");
                    SQL_INSERT_MAIN_EVENT.Append(" ,me_status ");
                    SQL_INSERT_MAIN_EVENT.Append(" ,me_note ");
                    SQL_INSERT_MAIN_EVENT.Append(" ,me_case_state ");
                    SQL_INSERT_MAIN_EVENT.Append(" ,me_end_with ");
                    SQL_INSERT_MAIN_EVENT.Append(" ) VALUES (");
                    SQL_INSERT_MAIN_EVENT.AppendFormat("'{0}'", hn);
                    SQL_INSERT_MAIN_EVENT.AppendFormat(",'{0}'", datetime);
                    SQL_INSERT_MAIN_EVENT.AppendFormat(",'{0}'", chief_complaint);
                    SQL_INSERT_MAIN_EVENT.AppendFormat(",'{0}'", vs);
                    SQL_INSERT_MAIN_EVENT.AppendFormat(",{0}", baby_weight.PadLeft(1, '0'));
                    SQL_INSERT_MAIN_EVENT.AppendFormat(",{0}", baby_weight_twin.PadLeft(1, '0'));
                    SQL_INSERT_MAIN_EVENT.AppendFormat(",'{0}'", baby_fhs);
                    SQL_INSERT_MAIN_EVENT.AppendFormat(",'{0}'", baby_fhs_note);
                    SQL_INSERT_MAIN_EVENT.AppendFormat(",'{0}'", baby_fhs_twin);
                    SQL_INSERT_MAIN_EVENT.AppendFormat(",'{0}'", baby_fhs_twin_note.PadLeft(1, '0'));
                    SQL_INSERT_MAIN_EVENT.AppendFormat(",{0}", utene.PadLeft(1, '0'));
                    SQL_INSERT_MAIN_EVENT.AppendFormat(",{0}", pv_dilate.PadLeft(1, '0'));
                    SQL_INSERT_MAIN_EVENT.AppendFormat(",{0}", pv_effacement.PadLeft(1, '0'));
                    SQL_INSERT_MAIN_EVENT.AppendFormat(",'{0}'", pv_membrane);
                    SQL_INSERT_MAIN_EVENT.AppendFormat(",'{0}'", pv_membrane_note);
                    SQL_INSERT_MAIN_EVENT.AppendFormat(",{0}", pv_station.PadLeft(1, '0'));
                    SQL_INSERT_MAIN_EVENT.AppendFormat(",'{0}'", pv_present);
                    SQL_INSERT_MAIN_EVENT.AppendFormat(",'{0}'", pv_present_twin);
                    SQL_INSERT_MAIN_EVENT.AppendFormat(",'{0}'", plan);
                    SQL_INSERT_MAIN_EVENT.AppendFormat(",'{0}'", status);
                    SQL_INSERT_MAIN_EVENT.AppendFormat(",'{0}'", note);
                    SQL_INSERT_MAIN_EVENT.Append(",1 ");
                    SQL_INSERT_MAIN_EVENT.Append(",'' ");
                    SQL_INSERT_MAIN_EVENT.Append(" );");

                    MySqlCommand CMD_INSERT_MAIN_EVENT = new MySqlCommand(SQL_INSERT_MAIN_EVENT.ToString(), conn);
                    CMD_INSERT_MAIN_EVENT.ExecuteNonQuery();
                    conn.Close();
                }

                //-------------------------- SELECT me_id FROM tbl_main_event ---------------------------------
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                    StringBuilder SQL_SELECT_ME = new StringBuilder();
                    SQL_SELECT_ME.Append(" SELECT me_id FROM tbl_main_event ORDER BY me_id DESC LIMIT 1 ");

                    MySqlCommand CMD_SELECT_ME = new MySqlCommand(SQL_SELECT_ME.ToString(), conn);
                    MySqlDataReader SELECT_ME_DataReader = CMD_SELECT_ME.ExecuteReader();
                    if (SELECT_ME_DataReader.Read())
                    {
                        me_id = Convert.ToInt32(SELECT_ME_DataReader[0]);
                    }
                    conn.Close();
                }

                //-------------------------- INSERT tbl_sub_event ---------------------------------
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                    StringBuilder SQL_INSERT_SUB_EVENT = new StringBuilder();
                    SQL_INSERT_SUB_EVENT.Append(" INSERT INTO tbl_sub_event ( ");
                    SQL_INSERT_SUB_EVENT.Append(" me_id ");
                    SQL_INSERT_SUB_EVENT.Append(" ,se_datetime ");
                    SQL_INSERT_SUB_EVENT.Append(" ,se_fhs ");
                    SQL_INSERT_SUB_EVENT.Append(" ,se_fhs_note ");
                    SQL_INSERT_SUB_EVENT.Append(" ,se_fhs_twin ");
                    SQL_INSERT_SUB_EVENT.Append(" ,se_fhs_twin_note ");
                    SQL_INSERT_SUB_EVENT.Append(" ,se_uc ");
                    SQL_INSERT_SUB_EVENT.Append(" ,se_pv_dilate ");
                    SQL_INSERT_SUB_EVENT.Append(" ,se_pv_effacement ");
                    SQL_INSERT_SUB_EVENT.Append(" ,se_pv_membrane ");
                    SQL_INSERT_SUB_EVENT.Append(" ,se_pv_membrane_note ");
                    SQL_INSERT_SUB_EVENT.Append(" ,se_pv_station ");
                    SQL_INSERT_SUB_EVENT.Append(" ,se_pv_present ");
                    SQL_INSERT_SUB_EVENT.Append(" ,se_pv_present_twin ");
                    SQL_INSERT_SUB_EVENT.Append(" ,se_plan ");
                    SQL_INSERT_SUB_EVENT.Append(" ,se_status ");
                    SQL_INSERT_SUB_EVENT.Append(" ,se_note ");
                    SQL_INSERT_SUB_EVENT.Append(" ,se_type ");
                    SQL_INSERT_SUB_EVENT.Append(" ,se_case_state ");
                    SQL_INSERT_SUB_EVENT.Append(" ) VALUES (");
                    SQL_INSERT_SUB_EVENT.AppendFormat("{0}", me_id);
                    SQL_INSERT_SUB_EVENT.AppendFormat(",'{0}'", datetime);
                    SQL_INSERT_SUB_EVENT.AppendFormat(",'{0}'", baby_fhs);
                    SQL_INSERT_SUB_EVENT.AppendFormat(",'{0}'", baby_fhs_note);
                    SQL_INSERT_SUB_EVENT.AppendFormat(",'{0}'", baby_fhs_twin);
                    SQL_INSERT_SUB_EVENT.AppendFormat(",'{0}'", baby_fhs_twin_note);
                    SQL_INSERT_SUB_EVENT.AppendFormat(",{0}", utene.PadLeft(1, '0'));
                    SQL_INSERT_SUB_EVENT.AppendFormat(",{0}", pv_dilate.PadLeft(1, '0'));
                    SQL_INSERT_SUB_EVENT.AppendFormat(",{0}", pv_effacement.PadLeft(1, '0'));
                    SQL_INSERT_SUB_EVENT.AppendFormat(",'{0}'", pv_membrane);
                    SQL_INSERT_SUB_EVENT.AppendFormat(",'{0}'", pv_membrane_note);
                    SQL_INSERT_SUB_EVENT.AppendFormat(",{0}", pv_station.PadLeft(1, '0'));
                    SQL_INSERT_SUB_EVENT.AppendFormat(",'{0}'", pv_present);
                    SQL_INSERT_SUB_EVENT.AppendFormat(",'{0}'", pv_present_twin);
                    SQL_INSERT_SUB_EVENT.AppendFormat(",'{0}'", plan);
                    SQL_INSERT_SUB_EVENT.AppendFormat(",'{0}'", status);
                    SQL_INSERT_SUB_EVENT.AppendFormat(",'{0}'", note);
                    SQL_INSERT_SUB_EVENT.Append(",'EVENT'");
                    SQL_INSERT_SUB_EVENT.Append(", 1");
                    SQL_INSERT_SUB_EVENT.Append(" );");

                    MySqlCommand CMD_INSERT_SUB_EVENT = new MySqlCommand(SQL_INSERT_SUB_EVENT.ToString(), conn);
                    CMD_INSERT_SUB_EVENT.ExecuteNonQuery();
                    conn.Close();
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool AddANC()
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(connectionstr);


                //-------------------------- INSERT tbl_anc ---------------------------------
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                    StringBuilder SQL_INSERT_ANC = new StringBuilder();
                    SQL_INSERT_ANC.Append(" INSERT INTO tbl_anc ( ");
                    SQL_INSERT_ANC.Append(" pt_hn ");
                    SQL_INSERT_ANC.Append(", anc_at ");
                    SQL_INSERT_ANC.Append(", anc_times ");
                    SQL_INSERT_ANC.Append(", anc_case_state ");
                    SQL_INSERT_ANC.Append(" ) VALUES ( ");
                    SQL_INSERT_ANC.AppendFormat("'{0}'", hn);
                    SQL_INSERT_ANC.AppendFormat(", '{0}'", anc_at);
                    SQL_INSERT_ANC.AppendFormat(", {0}", anc_times);
                    SQL_INSERT_ANC.Append(", 1");
                    SQL_INSERT_ANC.Append(" );");

                    MySqlCommand CMD_INSERT_ANC = new MySqlCommand(SQL_INSERT_ANC.ToString(), conn);
                    CMD_INSERT_ANC.ExecuteNonQuery();
                    conn.Close();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public DataTable GetAllBedInfo()
        {
            MySqlConnection conn = new MySqlConnection(connectionstr);
            DataTable dtBedInfo = new DataTable();
            StringBuilder SQL_SELECT_ALL_BED_INFO = new StringBuilder();

            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    SQL_SELECT_ALL_BED_INFO.AppendFormat("SELECT bed_no, IFNULL(tbl_patient.pt_hn, 'Empty') as 'pt_hn' , IFNULL(pt_name, 'Empty') as 'pt_name', bed_zone FROM tbl_bed LEFT OUTER JOIN tbl_patient ON tbl_bed.pt_hn = tbl_patient.pt_hn");

                    conn.Open();
                    MySqlCommand CMD_SELECT_ALL_BED_INFO = new MySqlCommand(SQL_SELECT_ALL_BED_INFO.ToString(), conn);
                    CMD_SELECT_ALL_BED_INFO.ExecuteNonQuery();
                    MySqlDataAdapter DA_ALL_BEB_INFO = new MySqlDataAdapter(CMD_SELECT_ALL_BED_INFO);
                    DA_ALL_BEB_INFO.Fill(dtBedInfo);
                    conn.Close();
                }
                return dtBedInfo;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public bool AddNewEvent()
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(connectionstr);
                StringBuilder SQL_UPDATE_MAIN_EVENT = new StringBuilder();

                //-------------------------- SELECT * FROM tbl_main_event ---------------------------------
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                    StringBuilder SQL_SELECT_ME = new StringBuilder();
                    SQL_SELECT_ME.AppendFormat(" SELECT * FROM tbl_main_event WHERE pt_hn = '{0}' AND me_case_state = 1", hn);

                    MySqlCommand CMD_SELECT_ME = new MySqlCommand(SQL_SELECT_ME.ToString(), conn);
                    MySqlDataReader SELECT_ME_DataReader = CMD_SELECT_ME.ExecuteReader();
                    if (SELECT_ME_DataReader.Read())
                    {
                        me_id = Convert.ToInt32(SELECT_ME_DataReader["me_id"]);

                        if(saveas == "EVENT")
                        {
                            SQL_UPDATE_MAIN_EVENT.AppendFormat(" UPDATE tbl_main_event SET me_datetime = '{0}'", datetime);

                            if (SELECT_ME_DataReader["me_baby_fhs"].ToString() != baby_fhs && baby_fhs != string.Empty)
                            {
                                SQL_UPDATE_MAIN_EVENT.AppendFormat(" , me_baby_fhs = '{0}' ", baby_fhs);
                            }

                            if (SELECT_ME_DataReader["me_baby_fhs_note"].ToString() != baby_fhs_note && baby_fhs_note != string.Empty)
                            {
                                SQL_UPDATE_MAIN_EVENT.AppendFormat(" , me_baby_fhs_note = '{0}' ", baby_fhs_note);
                            }

                            if (SELECT_ME_DataReader["me_baby_fhs_twin"].ToString() != baby_fhs_twin && baby_fhs_twin != string.Empty)
                            {
                                SQL_UPDATE_MAIN_EVENT.AppendFormat(" , me_baby_fhs_twin = '{0}' ", baby_fhs_twin);
                            }

                            if (SELECT_ME_DataReader["me_baby_fhs_twin_note"].ToString() != baby_fhs_twin_note && baby_fhs_twin_note != string.Empty)
                            {
                                SQL_UPDATE_MAIN_EVENT.AppendFormat(" , me_baby_fhs_twin_note = '{0}' ", baby_fhs_twin_note);
                            }

                            if (SELECT_ME_DataReader["me_utene"].ToString() != utene && utene != string.Empty)
                            {
                                SQL_UPDATE_MAIN_EVENT.AppendFormat(" , me_utene = {0} ", utene);
                            }

                            if (SELECT_ME_DataReader["me_pv_dilate"].ToString() != pv_dilate && pv_dilate != string.Empty)
                            {
                                SQL_UPDATE_MAIN_EVENT.AppendFormat(" , me_pv_dilate = {0} ", pv_dilate);
                            }

                            if (SELECT_ME_DataReader["me_pv_effacement"].ToString() != pv_effacement && pv_effacement != string.Empty)
                            {
                                SQL_UPDATE_MAIN_EVENT.AppendFormat(" , me_pv_effacement = {0} ", pv_effacement);
                            }

                            if (SELECT_ME_DataReader["me_pv_membrane"].ToString() != pv_membrane && pv_membrane != string.Empty)
                            {
                                SQL_UPDATE_MAIN_EVENT.AppendFormat(" , me_pv_membrane = '{0}' ", pv_membrane);
                            }

                            if (SELECT_ME_DataReader["me_pv_membrane_note"].ToString() != pv_membrane_note && pv_membrane_note != string.Empty)
                            {
                                SQL_UPDATE_MAIN_EVENT.AppendFormat(" , me_pv_membrane_note = '{0}' ", pv_membrane_note);
                            }

                            if (SELECT_ME_DataReader["me_pv_station"].ToString() != pv_station && pv_station != string.Empty)
                            {
                                SQL_UPDATE_MAIN_EVENT.AppendFormat(" , me_pv_station = {0} ", pv_station);
                            }

                            if (SELECT_ME_DataReader["me_pv_present"].ToString() != pv_present && pv_present != string.Empty)
                            {
                                SQL_UPDATE_MAIN_EVENT.AppendFormat(" , me_pv_present = '{0}' ", pv_present);
                            }

                            if (SELECT_ME_DataReader["me_pv_present_twin"].ToString() != pv_present_twin && pv_present_twin != string.Empty)
                            {
                                SQL_UPDATE_MAIN_EVENT.AppendFormat(" , me_pv_present_twin = '{0}' ", pv_present_twin);
                            }

                            if (SELECT_ME_DataReader["me_plan"].ToString() != plan && plan != string.Empty)
                            {
                                SQL_UPDATE_MAIN_EVENT.AppendFormat(" , me_plan = '{0}' ", plan);
                            }

                            if (SELECT_ME_DataReader["me_status"].ToString() != status && status != string.Empty)
                            {
                                SQL_UPDATE_MAIN_EVENT.AppendFormat(" , me_status = '{0}' ", status);
                            }

                            if (SELECT_ME_DataReader["me_note"].ToString() != note && note != string.Empty)
                            {
                                SQL_UPDATE_MAIN_EVENT.AppendFormat(" , me_note = '{0}' ", note);
                            }

                            SQL_UPDATE_MAIN_EVENT.AppendFormat(" WHERE pt_hn = '{0}' ", hn);
                        }
                    }
                    conn.Close();
                }

                //-------------------------- INSERT tbl_sub_event ---------------------------------
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                    StringBuilder SQL_INSERT_SUB_EVENT = new StringBuilder();
                    SQL_INSERT_SUB_EVENT.Append(" INSERT INTO tbl_sub_event ( ");
                    SQL_INSERT_SUB_EVENT.Append(" me_id ");
                    SQL_INSERT_SUB_EVENT.Append(" ,se_datetime ");
                    SQL_INSERT_SUB_EVENT.Append(" ,se_fhs ");
                    SQL_INSERT_SUB_EVENT.Append(" ,se_fhs_note ");
                    SQL_INSERT_SUB_EVENT.Append(" ,se_fhs_twin ");
                    SQL_INSERT_SUB_EVENT.Append(" ,se_fhs_twin_note ");
                    SQL_INSERT_SUB_EVENT.Append(" ,se_uc ");
                    SQL_INSERT_SUB_EVENT.Append(" ,se_pv_dilate ");
                    SQL_INSERT_SUB_EVENT.Append(" ,se_pv_effacement ");
                    SQL_INSERT_SUB_EVENT.Append(" ,se_pv_membrane ");
                    SQL_INSERT_SUB_EVENT.Append(" ,se_pv_membrane_note ");
                    SQL_INSERT_SUB_EVENT.Append(" ,se_pv_station ");
                    SQL_INSERT_SUB_EVENT.Append(" ,se_pv_present ");
                    SQL_INSERT_SUB_EVENT.Append(" ,se_pv_present_twin ");
                    SQL_INSERT_SUB_EVENT.Append(" ,se_plan ");
                    SQL_INSERT_SUB_EVENT.Append(" ,se_status ");
                    SQL_INSERT_SUB_EVENT.Append(" ,se_note ");
                    SQL_INSERT_SUB_EVENT.Append(" ,se_type ");
                    SQL_INSERT_SUB_EVENT.Append(" ,se_case_state ");
                    SQL_INSERT_SUB_EVENT.Append(" ) VALUES (");
                    SQL_INSERT_SUB_EVENT.AppendFormat("{0}", me_id);
                    SQL_INSERT_SUB_EVENT.AppendFormat(",'{0}'", datetime);
                    SQL_INSERT_SUB_EVENT.AppendFormat(",'{0}'", baby_fhs);
                    SQL_INSERT_SUB_EVENT.AppendFormat(",'{0}'", baby_fhs_note);
                    SQL_INSERT_SUB_EVENT.AppendFormat(",'{0}'", baby_fhs_twin);
                    SQL_INSERT_SUB_EVENT.AppendFormat(",'{0}'", baby_fhs_twin_note);
                    SQL_INSERT_SUB_EVENT.AppendFormat(",{0}", utene);
                    SQL_INSERT_SUB_EVENT.AppendFormat(",{0}", pv_dilate);
                    SQL_INSERT_SUB_EVENT.AppendFormat(",{0}", pv_effacement);
                    SQL_INSERT_SUB_EVENT.AppendFormat(",'{0}'", pv_membrane);
                    SQL_INSERT_SUB_EVENT.AppendFormat(",'{0}'", pv_membrane_note);
                    SQL_INSERT_SUB_EVENT.AppendFormat(",{0}", pv_station);
                    SQL_INSERT_SUB_EVENT.AppendFormat(",'{0}'", pv_present);
                    SQL_INSERT_SUB_EVENT.AppendFormat(",'{0}'", pv_present_twin);
                    SQL_INSERT_SUB_EVENT.AppendFormat(",'{0}'", plan);
                    SQL_INSERT_SUB_EVENT.AppendFormat(",'{0}'", status);
                    SQL_INSERT_SUB_EVENT.AppendFormat(",'{0}'", note);
                    SQL_INSERT_SUB_EVENT.AppendFormat(",'{0}'", saveas);
                    SQL_INSERT_SUB_EVENT.AppendFormat(",'1'");
                    SQL_INSERT_SUB_EVENT.Append(" );");

                    MySqlCommand CMD_INSERT_SUB_EVENT = new MySqlCommand(SQL_INSERT_SUB_EVENT.ToString(), conn);
                    CMD_INSERT_SUB_EVENT.ExecuteNonQuery();
                    conn.Close();
                }

                //-------------------------- UPDATE tbl_main_event ---------------------------------
                if (saveas == "EVENT")
                {
                    if (conn.State == ConnectionState.Closed)
                    {
                        conn.Open();
                        MySqlCommand CMD_UPDATE_MAIN_EVENT = new MySqlCommand(SQL_UPDATE_MAIN_EVENT.ToString(), conn);
                        CMD_UPDATE_MAIN_EVENT.ExecuteNonQuery();
                        conn.Close();
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public DataTable GetAllPatientInfo()
        {
            MySqlConnection conn = new MySqlConnection(connectionstr);
            DataTable dtPatientInfo = new DataTable();
            StringBuilder SQL_SELECT_ALL_PATIENT_INFO = new StringBuilder();

            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    SQL_SELECT_ALL_PATIENT_INFO.AppendFormat("SELECT tbl_patient.*, tbl_main_event.*, tbl_bed.bed_no, tbl_bed.bed_zone FROM tbl_patient LEFT JOIN tbl_bed ON tbl_patient.bed_id = tbl_bed.bed_id LEFT JOIN tbl_main_event ON tbl_patient.pt_hn = tbl_main_event.pt_hn WHERE tbl_main_event.me_case_state = 1 ORDER BY tbl_bed.bed_no");

                    conn.Open();
                    MySqlCommand CMD_SELECT_ALL_PATIENT_INFO = new MySqlCommand(SQL_SELECT_ALL_PATIENT_INFO.ToString(), conn);
                    CMD_SELECT_ALL_PATIENT_INFO.ExecuteNonQuery();
                    MySqlDataAdapter DA_ALL_PATIENT_INFO = new MySqlDataAdapter(CMD_SELECT_ALL_PATIENT_INFO);
                    DA_ALL_PATIENT_INFO.Fill(dtPatientInfo);
                    conn.Close();
                }
                return dtPatientInfo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetAllHistory()
        {
            MySqlConnection conn = new MySqlConnection(connectionstr);
            DataTable dtPatientInfo = new DataTable();
            StringBuilder SQL_SELECT_ALL_PATIENT_INFO = new StringBuilder();

            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    SQL_SELECT_ALL_PATIENT_INFO.AppendFormat("SELECT tbl_patient.*, tbl_main_event.*, tbl_endwithdeliver.*, tbl_endwithoutdeliver.* FROM tbl_patient LEFT JOIN tbl_main_event ON tbl_patient.pt_hn = tbl_main_event.pt_hn LEFT JOIN tbl_endwithdeliver ON tbl_main_event.me_id = tbl_endwithdeliver.me_id LEFT JOIN tbl_endwithoutdeliver ON tbl_main_event.me_id = tbl_endwithoutdeliver.me_id WHERE tbl_main_event.me_case_state = 0");

                    conn.Open();
                    MySqlCommand CMD_SELECT_ALL_PATIENT_INFO = new MySqlCommand(SQL_SELECT_ALL_PATIENT_INFO.ToString(), conn);
                    CMD_SELECT_ALL_PATIENT_INFO.ExecuteNonQuery();
                    MySqlDataAdapter DA_ALL_PATIENT_INFO = new MySqlDataAdapter(CMD_SELECT_ALL_PATIENT_INFO);
                    DA_ALL_PATIENT_INFO.Fill(dtPatientInfo);
                    conn.Close();
                }
                return dtPatientInfo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetAllEvent(string hn)
        {
            MySqlConnection conn = new MySqlConnection(connectionstr);
            DataTable dtEvent = new DataTable();
            StringBuilder SQL_SELECT_ALL_EVENT_INFO = new StringBuilder();

            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    SQL_SELECT_ALL_EVENT_INFO.AppendFormat("SELECT tbl_bed.bed_no, tbl_bed.bed_zone, tbl_patient.pt_hn, tbl_sub_event.* FROM tbl_patient LEFT JOIN tbl_bed ON tbl_patient.bed_id = tbl_bed.bed_id LEFT JOIN tbl_main_event ON tbl_patient.pt_hn = tbl_main_event.pt_hn LEFT JOIN tbl_sub_event ON tbl_main_event.me_id = tbl_sub_event.me_id WHERE tbl_sub_event.se_case_state = 1 AND tbl_bed.pt_hn = '{0}' ORDER BY tbl_sub_event.se_datetime", hn);

                    conn.Open();
                    MySqlCommand CMD_SELECT_ALL_EVENT_INFO = new MySqlCommand(SQL_SELECT_ALL_EVENT_INFO.ToString(), conn);
                    CMD_SELECT_ALL_EVENT_INFO.ExecuteNonQuery();
                    MySqlDataAdapter DA_ALL_EVENT_INFO = new MySqlDataAdapter(CMD_SELECT_ALL_EVENT_INFO);
                    DA_ALL_EVENT_INFO.Fill(dtEvent);
                    conn.Close();
                }
                return dtEvent;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetAllHistoryEvent(string hn)
        {
            MySqlConnection conn = new MySqlConnection(connectionstr);
            DataTable dtEvent = new DataTable();
            StringBuilder SQL_SELECT_ALL_EVENT_INFO = new StringBuilder();

            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    SQL_SELECT_ALL_EVENT_INFO.AppendFormat("SELECT tbl_bed.bed_no, tbl_bed.bed_zone, tbl_patient.pt_hn, tbl_sub_event.* FROM tbl_patient LEFT JOIN tbl_bed ON tbl_patient.bed_id = tbl_bed.bed_id LEFT JOIN tbl_main_event ON tbl_patient.pt_hn = tbl_main_event.pt_hn LEFT JOIN tbl_sub_event ON tbl_main_event.me_id = tbl_sub_event.me_id WHERE tbl_sub_event.se_case_state = 0 AND tbl_main_event.pt_hn = '{0}' ORDER BY tbl_sub_event.se_datetime", hn);

                    conn.Open();
                    MySqlCommand CMD_SELECT_ALL_EVENT_INFO = new MySqlCommand(SQL_SELECT_ALL_EVENT_INFO.ToString(), conn);
                    CMD_SELECT_ALL_EVENT_INFO.ExecuteNonQuery();
                    MySqlDataAdapter DA_ALL_EVENT_INFO = new MySqlDataAdapter(CMD_SELECT_ALL_EVENT_INFO);
                    DA_ALL_EVENT_INFO.Fill(dtEvent);
                    conn.Close();
                }
                return dtEvent;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetPreviousData()
        {
            MySqlConnection conn = new MySqlConnection(connectionstr);
            DataTable dt = new DataTable();
            StringBuilder SQL_SELECT_SUB_EVENT = new StringBuilder();

            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    SQL_SELECT_SUB_EVENT.AppendFormat("SELECT tbl_main_event.pt_hn, tbl_sub_event.* FROM tbl_sub_event LEFT JOIN tbl_main_event ON tbl_sub_event.me_id = tbl_main_event.me_id WHERE tbl_main_event.pt_hn = '{0}' ORDER BY se_id DESC LIMIT 1", hn);

                    conn.Open();
                    MySqlCommand CMD_SELECT_SUB_EVENT = new MySqlCommand(SQL_SELECT_SUB_EVENT.ToString(), conn);
                    CMD_SELECT_SUB_EVENT.ExecuteNonQuery();
                    MySqlDataAdapter DA_ALL_BEB_INFO = new MySqlDataAdapter(CMD_SELECT_SUB_EVENT);
                    DA_ALL_BEB_INFO.Fill(dt);
                    conn.Close();
                }
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool EndWithDelivery()
        {
            MySqlConnection conn = new MySqlConnection(connectionstr);
            StringBuilder SQL_INSERT_END_CASE = new StringBuilder();
            StringBuilder SQL_UPDATE_MAIN_EVENT = new StringBuilder();
            StringBuilder SQL_UPDATE_SUB_EVENT = new StringBuilder();
            StringBuilder SQL_UPDATE_BED = new StringBuilder();
            StringBuilder SQL_UPDATE_ANC = new StringBuilder();

            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                    StringBuilder SQL_SELECT_ME = new StringBuilder();
                    SQL_SELECT_ME.AppendFormat(" SELECT me_id FROM tbl_main_event WHERE pt_hn = '{0}' ORDER BY me_id DESC LIMIT 1", hn);
                    MySqlCommand CMD_SELECT_ME = new MySqlCommand(SQL_SELECT_ME.ToString(), conn);
                    MySqlDataReader SELECT_ME_DataReader = CMD_SELECT_ME.ExecuteReader();
                    if (SELECT_ME_DataReader.Read())
                    {
                        SQL_INSERT_END_CASE.AppendFormat("INSERT INTO tbl_endwithdeliver (pt_hn, me_id, end_date, end_EFW, end_APGAR, end_follow) VALUES ('{0}', {1}, '{2}', '{3}', '{4}', '{5}');", hn, Convert.ToInt32(SELECT_ME_DataReader["me_id"]), datetime, endEFW, endAGPAR, follow);

                        SQL_UPDATE_MAIN_EVENT.AppendFormat(" UPDATE tbl_main_event SET me_case_state = 0, me_end_with = 'Delivery' WHERE me_id = {0}", Convert.ToInt32(SELECT_ME_DataReader["me_id"]));

                        SQL_UPDATE_SUB_EVENT.AppendFormat(" UPDATE tbl_sub_event SET se_case_state = 0 WHERE me_id = {0}", Convert.ToInt32(SELECT_ME_DataReader["me_id"]));

                        SQL_UPDATE_BED.AppendFormat(" UPDATE tbl_bed SET pt_hn = NULL, bed_admit_date = NULL WHERE pt_hn = '{0}'", hn);

                        SQL_UPDATE_ANC.AppendFormat(" UPDATE tbl_anc SET anc_case_state = 0 WHERE pt_hn = '{0}'", hn);
                    }
                    else
                    {
                        return false;
                    }
                    conn.Close();
                }

                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                    MySqlCommand CMD_INSERT_END_CASE = new MySqlCommand(SQL_INSERT_END_CASE.ToString(), conn);
                    CMD_INSERT_END_CASE.ExecuteNonQuery();
                    conn.Close();
                }

                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                    MySqlCommand CMD_UPDATE_MAIN_EVENT = new MySqlCommand(SQL_UPDATE_MAIN_EVENT.ToString(), conn);
                    CMD_UPDATE_MAIN_EVENT.ExecuteNonQuery();
                    conn.Close();
                }

                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                    MySqlCommand CMD_UPDATE_SUB_EVENT = new MySqlCommand(SQL_UPDATE_SUB_EVENT.ToString(), conn);
                    CMD_UPDATE_SUB_EVENT.ExecuteNonQuery();
                    conn.Close();
                }

                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                    MySqlCommand CMD_UPDATE_BED = new MySqlCommand(SQL_UPDATE_BED.ToString(), conn);
                    CMD_UPDATE_BED.ExecuteNonQuery();
                    conn.Close();
                }

                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                    MySqlCommand CMD_UPDATE_ANC = new MySqlCommand(SQL_UPDATE_ANC.ToString(), conn);
                    CMD_UPDATE_ANC.ExecuteNonQuery();
                    conn.Close();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
        }

        public bool EndWithOutDelivery()
        {
            MySqlConnection conn = new MySqlConnection(connectionstr);
            StringBuilder SQL_INSERT_END_CASE = new StringBuilder();
            StringBuilder SQL_UPDATE_MAIN_EVENT = new StringBuilder();
            StringBuilder SQL_UPDATE_SUB_EVENT = new StringBuilder();
            StringBuilder SQL_UPDATE_BED = new StringBuilder();
            StringBuilder SQL_UPDATE_ANC = new StringBuilder();

            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                    StringBuilder SQL_SELECT_ME = new StringBuilder();
                    SQL_SELECT_ME.AppendFormat(" SELECT me_id FROM tbl_main_event WHERE pt_hn = '{0}' ORDER BY me_id DESC LIMIT 1", hn);
                    MySqlCommand CMD_SELECT_ME = new MySqlCommand(SQL_SELECT_ME.ToString(), conn);
                    MySqlDataReader SELECT_ME_DataReader = CMD_SELECT_ME.ExecuteReader();
                    if (SELECT_ME_DataReader.Read())
                    {
                        SQL_INSERT_END_CASE.AppendFormat(" INSERT INTO tbl_endwithoutdeliver (pt_hn, me_id, end_without_date, end_deliver_status) VALUES ('{0}', {1}, '{2}', '{3}');", hn, Convert.ToInt32(SELECT_ME_DataReader["me_id"]), datetime, delivery);

                        SQL_UPDATE_MAIN_EVENT.AppendFormat(" UPDATE tbl_main_event SET me_case_state = 0, me_end_with = 'Out of Delivery' WHERE me_id = {0}", Convert.ToInt32(SELECT_ME_DataReader["me_id"]));

                        SQL_UPDATE_SUB_EVENT.AppendFormat(" UPDATE tbl_sub_event SET se_case_state = 0 WHERE me_id = {0}", Convert.ToInt32(SELECT_ME_DataReader["me_id"]));

                        SQL_UPDATE_BED.AppendFormat(" UPDATE tbl_bed SET pt_hn = NULL, bed_admit_date = NULL WHERE pt_hn = '{0}'", hn);

                        SQL_UPDATE_ANC.AppendFormat(" UPDATE tbl_anc SET anc_case_state = 0 WHERE pt_hn = '{0}'", hn);
                    }
                    else
                    {
                        return false;
                    }
                    conn.Close();
                }

                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                    MySqlCommand CMD_INSERT_END_CASE = new MySqlCommand(SQL_INSERT_END_CASE.ToString(), conn);
                    CMD_INSERT_END_CASE.ExecuteNonQuery();
                    conn.Close();
                }

                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                    MySqlCommand CMD_UPDATE_MAIN_EVENT = new MySqlCommand(SQL_UPDATE_MAIN_EVENT.ToString(), conn);
                    CMD_UPDATE_MAIN_EVENT.ExecuteNonQuery();
                    conn.Close();
                }

                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                    MySqlCommand CMD_UPDATE_SUB_EVENT = new MySqlCommand(SQL_UPDATE_SUB_EVENT.ToString(), conn);
                    CMD_UPDATE_SUB_EVENT.ExecuteNonQuery();
                    conn.Close();
                }

                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                    MySqlCommand CMD_UPDATE_BED = new MySqlCommand(SQL_UPDATE_BED.ToString(), conn);
                    CMD_UPDATE_BED.ExecuteNonQuery();
                    conn.Close();
                }

                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                    MySqlCommand CMD_UPDATE_ANC = new MySqlCommand(SQL_UPDATE_ANC.ToString(), conn);
                    CMD_UPDATE_ANC.ExecuteNonQuery();
                    conn.Close();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
        }

        public string MoveBed()
        {
            MySqlConnection conn = new MySqlConnection(connectionstr);

            try
            {
                //-----------------------    Is BED Empty?   --------------------
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                    StringBuilder SQL_SELECT_HN = new StringBuilder();
                    SQL_SELECT_HN.AppendFormat("SELECT pt_hn FROM tbl_bed WHERE bed_no = {0} AND bed_zone = '{1}'", toBed, toZone);
                    MySqlCommand CMD_SELECT_HN = new MySqlCommand(SQL_SELECT_HN.ToString(), conn);
                    MySqlDataReader SELECT_HN_DataReader = CMD_SELECT_HN.ExecuteReader();
                    if (SELECT_HN_DataReader.Read())
                    {
                        if (SELECT_HN_DataReader["pt_hn"].ToString() != string.Empty)
                        {
                            return "201";
                        }
                    }
                    conn.Close();
                }

                //----------------------   Set NULL Old Bed   --------------------
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                    StringBuilder SQL_UPDATE_BED = new StringBuilder();
                    SQL_UPDATE_BED.AppendFormat("UPDATE tbl_bed SET pt_hn = NULL, bed_admit_date = NULL WHERE pt_hn = '{0}'", hn);
                    MySqlCommand CMD_UPDATE_BED = new MySqlCommand(SQL_UPDATE_BED.ToString(), conn);
                    CMD_UPDATE_BED.ExecuteNonQuery();
                    conn.Close();
                }

                //---------------------   Update new BED   ----------------------
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                    StringBuilder SQL_UPDATE_BED = new StringBuilder();
                    SQL_UPDATE_BED.AppendFormat("UPDATE tbl_bed SET pt_hn = '{0}', bed_admit_date = CURRENT_TIMESTAMP WHERE bed_no = {1} AND bed_zone = '{2}'", hn, toBed, toZone);
                    MySqlCommand CMD_UPDATE_BED = new MySqlCommand(SQL_UPDATE_BED.ToString(), conn);
                    CMD_UPDATE_BED.ExecuteNonQuery();
                    conn.Close();
                }

                //----------------------   Select New Bed ID   --------------------
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                    StringBuilder SQL_SELECT_ID = new StringBuilder();
                    SQL_SELECT_ID.AppendFormat("SELECT bed_id FROM tbl_bed WHERE pt_hn = '{0}'", hn);
                    MySqlCommand CMD_SELECT_ID = new MySqlCommand(SQL_SELECT_ID.ToString(), conn);
                    MySqlDataReader SELECT_ID_DataReader = CMD_SELECT_ID.ExecuteReader();
                    if (SELECT_ID_DataReader.Read())
                    {
                        bed_id = Convert.ToInt32(SELECT_ID_DataReader["bed_id"].ToString());
                    }
                    conn.Close();
                }

                //---------------------   Update new BED PT  ----------------------
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                    StringBuilder SQL_UPDATE_BED = new StringBuilder();
                    SQL_UPDATE_BED.AppendFormat("UPDATE tbl_patient SET bed_id = '{0}' WHERE pt_hn = '{1}'", bed_id, hn);
                    MySqlCommand CMD_UPDATE_BED = new MySqlCommand(SQL_UPDATE_BED.ToString(), conn);
                    CMD_UPDATE_BED.ExecuteNonQuery();
                    conn.Close();
                }

                return "100";
            }
            catch(Exception ex)
            {
                return "400";
            }
        }

        public DataTable GetPVChart()
        {
            MySqlConnection conn = new MySqlConnection(connectionstr);
            DataTable dtPVChart = new DataTable();
            StringBuilder SQL_SELECT_PV = new StringBuilder();

            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    SQL_SELECT_PV.AppendFormat("SELECT se.se_pv_dilate AS 'PV_Dilate', se.se_pv_station AS 'PV_Station' FROM tbl_main_event AS me LEFT JOIN tbl_sub_event AS se ON me.me_id = se.me_id WHERE me.me_case_state = 1 AND se.se_type = 'EVENT' AND me.pt_hn = '{0}' ORDER BY se.se_id ASC", hn);

                    conn.Open();
                    MySqlCommand CMD_SELECT_PV = new MySqlCommand(SQL_SELECT_PV.ToString(), conn);
                    CMD_SELECT_PV.ExecuteNonQuery();
                    MySqlDataAdapter DA_ALL_PV = new MySqlDataAdapter(CMD_SELECT_PV);
                    DA_ALL_PV.Fill(dtPVChart);
                    conn.Close();
                }
                return dtPVChart;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetPatientInfo()
        {
            MySqlConnection conn = new MySqlConnection(connectionstr);
            DataTable dtPatientInfo = new DataTable();
            StringBuilder SQL_SELECT_PATIENT_INFO = new StringBuilder();

            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    SQL_SELECT_PATIENT_INFO.AppendFormat("SELECT * FROM tbl_patient WHERE pt_hn = '{0}'", hn);

                    conn.Open();
                    MySqlCommand CMD_SELECT_PATIENT_INFO = new MySqlCommand(SQL_SELECT_PATIENT_INFO.ToString(), conn);
                    CMD_SELECT_PATIENT_INFO.ExecuteNonQuery();
                    MySqlDataAdapter DA_PATIENT_INFO = new MySqlDataAdapter(CMD_SELECT_PATIENT_INFO);
                    DA_PATIENT_INFO.Fill(dtPatientInfo);
                    conn.Close();
                }
                return dtPatientInfo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetANC(string hn)
        {
            MySqlConnection conn = new MySqlConnection(connectionstr);
            DataTable dtPatientInfo = new DataTable();
            StringBuilder SQL_SELECT_ANC = new StringBuilder();

            try
            {
                if (conn.State == ConnectionState.Closed)
                {
                    SQL_SELECT_ANC.AppendFormat("SELECT * FROM tbl_anc WHERE pt_hn = '{0}'", hn);

                    conn.Open();
                    MySqlCommand CMD_SELECT_ANC= new MySqlCommand(SQL_SELECT_ANC.ToString(), conn);
                    CMD_SELECT_ANC.ExecuteNonQuery();
                    MySqlDataAdapter DA_ANC = new MySqlDataAdapter(CMD_SELECT_ANC);
                    DA_ANC.Fill(dtPatientInfo);
                    conn.Close();
                }
                return dtPatientInfo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool EditPatient()
        {
            MySqlConnection conn = new MySqlConnection(connectionstr);
            StringBuilder SQL_UPDATE_PT= new StringBuilder();

            try
            {
                //-------------------------- SELECT * FROM tbl_patient ---------------------------------
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                    StringBuilder SQL_SELECT_PT = new StringBuilder();
                    SQL_SELECT_PT.AppendFormat(" SELECT * FROM tbl_patient WHERE pt_hn = '{0}'", hn);

                    MySqlCommand CMD_SELECT_PT = new MySqlCommand(SQL_SELECT_PT.ToString(), conn);
                    MySqlDataReader SELECT_PT_DataReader = CMD_SELECT_PT.ExecuteReader();
                    if (SELECT_PT_DataReader.Read())
                    {
                        SQL_UPDATE_PT.AppendFormat(" UPDATE tbl_patient SET pt_name = '{0}' ", name);

                        if (SELECT_PT_DataReader["pt_age"].ToString() != age && age != string.Empty)
                        {
                            SQL_UPDATE_PT.AppendFormat(" ,pt_age = {0} ", age);
                        }

                        if (SELECT_PT_DataReader["pt_gpal"].ToString() != gpal && gpal != string.Empty)
                        {
                            SQL_UPDATE_PT.AppendFormat(" ,pt_gpal = {0} ", gpal);
                        }

                        if (SELECT_PT_DataReader["pt_edc"].ToString() != edc && edc != string.Empty)
                        {
                            SQL_UPDATE_PT.AppendFormat(" ,pt_edc = '{0}' ", edc);
                        }

                        if (SELECT_PT_DataReader["pt_ga"].ToString() != ga && ga != string.Empty)
                        {
                            SQL_UPDATE_PT.AppendFormat(" ,pt_ga = '{0}' ", ga);
                        }

                        if (SELECT_PT_DataReader["pt_admit_times"].ToString() != admit_times && admit_times != string.Empty)
                        {
                            SQL_UPDATE_PT.AppendFormat(" ,pt_admit_times = {0} ", admit_times);
                        }

                        if (SELECT_PT_DataReader["pt_lab1"].ToString() != lab1 && lab1 != string.Empty)
                        {
                            SQL_UPDATE_PT.AppendFormat(" ,pt_lab1 = {0} ", lab1);
                        }

                        if (SELECT_PT_DataReader["pt_lab1_note"].ToString() != lab1_note && lab1_note != string.Empty)
                        {
                            SQL_UPDATE_PT.AppendFormat(" ,pt_lab1_note = '{0}' ", lab1_note);
                        }

                        if (SELECT_PT_DataReader["pt_lab2"].ToString() != lab2 && lab2 != string.Empty)
                        {
                            SQL_UPDATE_PT.AppendFormat(" ,pt_lab2 = {0} ", lab2);
                        }

                        if (SELECT_PT_DataReader["pt_lab2_note"].ToString() != lab2_note && lab2_note != string.Empty)
                        {
                            SQL_UPDATE_PT.AppendFormat(" ,pt_lab2_note = '{0}' ", lab2_note);
                        }

                        if (SELECT_PT_DataReader["pt_hct1"].ToString() != hct1 && hct1 != string.Empty)
                        {
                            SQL_UPDATE_PT.AppendFormat(" ,pt_hct1 = {0} ", hct1);
                        }

                        if (SELECT_PT_DataReader["pt_hct2"].ToString() != hct2 && hct2 != string.Empty)
                        {
                            SQL_UPDATE_PT.AppendFormat(" ,pt_hct2 = {0} ", hct2);
                        }

                        if (SELECT_PT_DataReader["pt_hct2"].ToString() != hct2 && hct2 != string.Empty)
                        {
                            SQL_UPDATE_PT.AppendFormat(" ,pt_hct2 = {0} ", hct2);
                        }

                        if (SELECT_PT_DataReader["pt_allergy"].ToString() != allergy && allergy != string.Empty)
                        {
                            SQL_UPDATE_PT.AppendFormat(" ,pt_allergy = {0} ", allergy);
                        }

                        if (SELECT_PT_DataReader["pt_allergy_note"].ToString() != allergy_note && allergy_note != string.Empty)
                        {
                            SQL_UPDATE_PT.AppendFormat(" ,pt_allergy_note = '{0}' ", allergy_note);
                        }

                        if (SELECT_PT_DataReader["pt_surgery"].ToString() != surgery && surgery != string.Empty)
                        {
                            SQL_UPDATE_PT.AppendFormat(" ,pt_surgery = {0} ", surgery);
                        }

                        if (SELECT_PT_DataReader["pt_surgery_note"].ToString() != surgery_note && surgery_note != string.Empty)
                        {
                            SQL_UPDATE_PT.AppendFormat(" ,pt_surgery_note = '{0}' ", surgery_note);
                        }

                        if (SELECT_PT_DataReader["pt_uc"].ToString() != uc && uc != string.Empty)
                        {
                            SQL_UPDATE_PT.AppendFormat(" ,pt_uc = {0} ", uc);
                        }

                        if (SELECT_PT_DataReader["pt_uc_note"].ToString() != uc_note && uc_note != string.Empty)
                        {
                            SQL_UPDATE_PT.AppendFormat(" ,pt_uc_note = '{0}' ", uc_note);
                        }

                        if (SELECT_PT_DataReader["pt_risk"].ToString() != risk && risk != string.Empty)
                        {
                            SQL_UPDATE_PT.AppendFormat(" ,pt_risk = {0} ", risk);
                        }

                        if (SELECT_PT_DataReader["pt_risk_note"].ToString() != risk_note && risk_note != string.Empty)
                        {
                            SQL_UPDATE_PT.AppendFormat(" ,pt_risk_note = '{0}' ", risk_note);
                        }

                        if (SELECT_PT_DataReader["pt_covid_status"].ToString() != covid_status && covid_status != string.Empty)
                        {
                            SQL_UPDATE_PT.AppendFormat(" ,pt_covid_status = '{0}' ", covid_status);
                        }

                        SQL_UPDATE_PT.AppendFormat(" WHERE pt_hn = '{0}' ", hn);
                    }
                    conn.Close();
                }

                //-------------------------- UPDATE tbl_patient ---------------------------------

                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                    MySqlCommand CMD_UPDATE_PT = new MySqlCommand(SQL_UPDATE_PT.ToString(), conn);
                    CMD_UPDATE_PT.ExecuteNonQuery();
                    conn.Close();
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
