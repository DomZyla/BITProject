using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastDrivers.Models
{
    public class Coordinator : INotifyPropertyChanged, IDataErrorInfo
    {

        /// <summary>
        /// private properties
        /// </summary>
        private int _personId;
        private int _coordinatorId;
        private string _title;
        private string _firstName;
        private string _lastName;
        private string _street;
        private string _suburb;
        private string _city;
        private int _postCode;
        private string _state;
        private int _phone;
        private int _mobile;
        private string _email;
        private string _gender;
        private string _username;
        private string _password;
        private bool _status;


        private SQLHelper _db;

        public Dictionary<string, string> ErrorCollection { get; set; } = new Dictionary<string, string>();

        public string Error
        {
            get
            {
                return null;
            }
        }

        /// <summary>
        /// Validation for string entries to not be null
        /// </summary>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public string this[string propertyName]
        {
            get
            {
                string result = null;
                switch (propertyName)
                {
                    case "Title":
                        if (string.IsNullOrWhiteSpace(Title))
                        {
                            result = "Title cannot be empty";
                        }
                        break;

                    case "FirstName":
                        if (string.IsNullOrWhiteSpace(FirstName))
                        {
                            result = "FirstName cannot be empty";
                        }
                        break;

                    case "LastName":
                        if (string.IsNullOrWhiteSpace(LastName))
                        {
                            result = "LastName cannot be empty";
                        }
                        break;

                    case "Street":
                        if (string.IsNullOrWhiteSpace(Street))
                        {
                            result = "Street cannot be empty";
                        }
                        break;

                    case "Suburb":
                        if (string.IsNullOrWhiteSpace(Suburb))
                        {
                            result = "Suburb cannot be empty";
                        }
                        break;

                    case "City":
                        if (string.IsNullOrWhiteSpace(City))
                        {
                            result = "City cannot be empty";
                        }
                        break;

                    case "Username":
                        if (string.IsNullOrWhiteSpace(Title))
                        {
                            result = "Username cannot be empty";
                        }
                        break;

                    case "State":
                        if (string.IsNullOrWhiteSpace(State))
                        {
                            result = "State cannot be empty";
                        }
                        break;

                    case "Email":
                        if (string.IsNullOrWhiteSpace(Email))
                        {
                            result = "Email cannot be empty";
                        }
                        break;

                    case "Gender":
                        if (string.IsNullOrWhiteSpace(Gender))
                        {
                            result = "Gender cannot be empty";
                        }
                        break;

                    case "Password":
                        if (string.IsNullOrWhiteSpace(Password))
                        {
                            result = "Password cannot be empty";
                        }
                        break;
                }
                if (result != null)
                {
                    ErrorCollection.Add(propertyName, result);
                }
                OnPropertyChanged("ErrorCollection");

                return result;
            }
        }


        //declare the event
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string prop)
        {
            if (PropertyChanged != null)
            {
                //calling the event
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }

        /// <summary>
        /// Public properties
        /// </summary>
        public bool Status
        {
            get
            {
                return _status;
            }
            set
            {
                _status = value;
            }
        }


        public int PersonId
        {
            get
            {
                return _personId;
            }
            set
            {
                _personId = value;
            }
        }

        public int CoordinatorId
        {
            get
            {
                return _coordinatorId;
            }
            set
            {
                _coordinatorId = value;
            }
        }

        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;
                OnPropertyChanged("Title");
            }
        }

        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                _firstName = value;
                OnPropertyChanged("FirstName");
            }
        }

        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                _lastName = value;
                OnPropertyChanged("LastName");
            }
        }

        public string Street
        {
            get
            {
                return _street;
            }
            set
            {
                _street = value;
                OnPropertyChanged("Street");
            }
        }

        public string Suburb
        {
            get
            {
                return _suburb;
            }
            set
            {
                _suburb = value;
                OnPropertyChanged("Suburb");
            }
        }

        public string City
        {
            get
            {
                return _city;
            }
            set
            {
                _city = value;
                OnPropertyChanged("City");
            }
        }

        public int PostCode
        {
            get
            {
                return _postCode;
            }
            set
            {
                _postCode = value;
            }
        }

        public string State
        {
            get
            {
                return _state;
            }
            set
            {
                _state = value;
                OnPropertyChanged("State");
            }
        }

        public int Phone
        {
            get
            {
                return _phone;
            }
            set
            {
                _phone = value;
            }
        }

        public int Mobile
        {
            get
            {
                return _mobile;
            }
            set
            {
                _mobile = value;
            }
        }

        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
                OnPropertyChanged("Email");
            }
        }

        public string Gender
        {
            get
            {
                return _gender;
            }
            set
            {
                _gender = value;
                OnPropertyChanged("Gender");
            }
        }

        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;
                OnPropertyChanged("Username");
            }
        }

        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                OnPropertyChanged("Password");
            }
        }
        public Coordinator()
        {

        }
        
        /// <summary>
        /// Datarow for Coordinator
        /// </summary>
        /// <param name="dr"></param>
        public Coordinator(DataRow dr)
        {
            CoordinatorId = Convert.ToInt32(dr["coordinator_Id"]);
            PersonId = Convert.ToInt32(dr["person_Id"]);
            Title = dr["title"].ToString();
            FirstName = dr["firstName"].ToString();
            LastName = dr["lastName"].ToString();
            Street = dr["street"].ToString();
            Suburb = dr["suburb"].ToString();
            City = dr["city"].ToString();
            PostCode = Convert.ToInt32(dr["postCode"]);
            State = dr["state"].ToString();
            Phone = Convert.ToInt32(dr["phone"]);
            Mobile = Convert.ToInt32(dr["mobile"]);
            Email = dr["email"].ToString();
            Gender = dr["gender"].ToString();
            Username = dr["username"].ToString();
            Password = dr["password"].ToString();
            Status = (Boolean)dr["status"];
        }

        /// <summary>
        /// Update Coordinator Object
        /// </summary>
        public void UpdateCoordinator()
        {
            string sql = "Update Person set Title = @title, " +
                       "FirstName = @firstName, " +
                       "LastName = @lastName, " +
                       "Street = @street, " +
                       "Suburb = @suburb, " +
                       "City = @city, " +
                       "PostCode = @postCode, " +
                       "State = @state, " +
                       "Phone = @phone, " +
                       "Mobile = @mobile, " +
                       "Email = @email, " +
                       "Gender = @gender, " +
                       "Username = @username, " +
                       "Password = @password " +
                       "where person_Id = @person_Id";

            _db = new SQLHelper();

            SqlParameter[] parameters = new SqlParameter[15];

            parameters[0] = new SqlParameter("@title", DbType.String);
            parameters[0].Value = Title;

            parameters[1] = new SqlParameter("@firstName", DbType.String);
            parameters[1].Value = FirstName;

            parameters[2] = new SqlParameter("@lastName", DbType.String);
            parameters[2].Value = LastName;

            parameters[3] = new SqlParameter("@street", DbType.String);
            parameters[3].Value = Street;

            parameters[4] = new SqlParameter("@suburb", DbType.String);
            parameters[4].Value = Suburb;

            parameters[5] = new SqlParameter("@city", DbType.String);
            parameters[5].Value = City;

            parameters[6] = new SqlParameter("@postCode", DbType.Int32);
            parameters[6].Value = PostCode;

            parameters[7] = new SqlParameter("@state", DbType.String);
            parameters[7].Value = State;

            parameters[8] = new SqlParameter("@phone", DbType.Int32);
            parameters[8].Value = Phone;

            parameters[9] = new SqlParameter("@mobile", DbType.Int32);
            parameters[9].Value = Mobile;

            parameters[10] = new SqlParameter("@email", DbType.String);
            parameters[10].Value = Email;

            parameters[11] = new SqlParameter("@gender", DbType.String);
            parameters[11].Value = Gender;

            parameters[12] = new SqlParameter("@username", DbType.String);
            parameters[12].Value = Username;

            parameters[13] = new SqlParameter("@password", DbType.String);
            parameters[13].Value = Password;

            parameters[14] = new SqlParameter("@person_Id", DbType.Int32);
            parameters[14].Value = PersonId;

            _db.ExecuteNonQuery(sql, parameters);

        }

        /// <summary>
        /// Delete Coordinator Object
        /// </summary>
        public void DeleteCoordinator()
        {
            string sql = "Update Person set Status = 0 " +
                "where person_Id = @person_Id";

            _db = new SQLHelper();

            SqlParameter[] parameters = new SqlParameter[2];

            parameters[0] = new SqlParameter("@status", DbType.String);
            parameters[0].Value = Status;

            parameters[1] = new SqlParameter("@person_Id", DbType.Int32);
            parameters[1].Value = PersonId;

            _db.ExecuteNonQuery(sql, parameters);
        }

        /// <summary>
        /// Insert Coordinator Object
        /// </summary>
        public void InsertCoordinator()
        {
            string sql = "declare @person_id int " + "INSERT into Person(Title,FirstName,LastName,Street,Suburb,City,PostCode,State,Phone,Mobile,Email,Gender,Username,Password) " +
            "VALUES ('" + Title + "','" + FirstName + "','" + LastName + "','" + Street + "','" + Suburb + "','" + City + "','" + PostCode + "','" + State + "','" + Phone + "','" + Mobile + "','" + Email + "','" + Gender + "','" + Username + "','" + Password + "')" + "set @person_id = SCOPE_IDENTITY() " + "INSERT into Coordinator(person_Id_Ref) " +
            "VALUES (@person_id)";

            _db = new SQLHelper();

            _db.ExecuteNonQuery(sql);
        }

        /// <summary>
        /// Collects all bookings for the Web application for coordinator login
        /// </summary>
        /// <returns></returns>
        public DataTable AllBookings()
        {

            string sql = "SELECT  jr.JobRequest_ID, cl.Client_ID ,p.FirstName, s.SkillName, jhl.Date, jhl.StartTime, jr.RequestStatus, jr.Kilometers " +
                "FROM Job_Request as jr,  Skill as s, Contractor as c, Job_Hour_Log as jhl, Person as p, Client as cl, Location as l " +
                "WHERE s.Skill_ID = jr.Skill_ID_Ref " +
                "AND c.Contractor_ID = jr.Contractor_ID_Ref " +
                "AND jhl.JobRequest_Ref = jr.JobRequest_ID " +
                "AND p.Person_ID = c.Person_ID_Ref " +
                "AND cl.Client_ID = l.Client_ID_Ref " +
                "AND l.Location_ID = jr.Location_Ref " +
                " order by jhl.Date";

            _db = new SQLHelper();

            DataTable allBookings = _db.ExecuteSQL(sql);

            return allBookings;

        }

        /// <summary>
        /// Collects all completed bookings for the Web application for coordinator login
        /// </summary>
        /// <returns></returns>
        public DataTable AllCompletedBookings()
        {

            string sql = "SELECT  jr.JobRequest_ID, cl.Client_ID ,p.FirstName, s.SkillName, jhl.Date, jhl.StartTime, jr.RequestStatus, jr.Kilometers " +
                "FROM Job_Request as jr,  Skill as s, Contractor as c, Job_Hour_Log as jhl, Person as p, Client as cl, Location as l " +
                "WHERE s.Skill_ID = jr.Skill_ID_Ref " +
                "AND c.Contractor_ID = jr.Contractor_ID_Ref " +
                "AND jhl.JobRequest_Ref = jr.JobRequest_ID " +
                "AND p.Person_ID = c.Person_ID_Ref " +
                "AND cl.Client_ID = l.Client_ID_Ref " +
                "AND l.Location_ID = jr.Location_Ref " +
                "AND jr.RequestStatus = 'Completed'" +
                " order by jhl.Date";

            _db = new SQLHelper();

            DataTable allCompletedBookings = _db.ExecuteSQL(sql);

            return allCompletedBookings;

        }

        /// <summary>
        /// Collects all past bookings for the Web application for coordinator login
        /// </summary>
        /// <returns></returns>
        public DataTable AllPastBookings()
        {

            string sql = "SELECT  jr.JobRequest_ID, cl.Client_ID ,p.FirstName, s.SkillName, jhl.Date, jhl.StartTime, jr.RequestStatus, jr.Kilometers " +
                "FROM Job_Request as jr,  Skill as s, Contractor as c, Job_Hour_Log as jhl, Person as p, Client as cl, Location as l " +
                "WHERE s.Skill_ID = jr.Skill_ID_Ref " +
                "AND c.Contractor_ID = jr.Contractor_ID_Ref " +
                "AND jhl.JobRequest_Ref = jr.JobRequest_ID " +
                "AND p.Person_ID = c.Person_ID_Ref " +
                "AND cl.Client_ID = l.Client_ID_Ref " +
                "AND l.Location_ID = jr.Location_Ref " +
                "AND (jr.RequestStatus = 'Send for payment' " +
                "OR jr.RequestStatus = 'Verified')" +
                " order by jhl.Date";

            _db = new SQLHelper();

            DataTable allPastBookings = _db.ExecuteSQL(sql);

            return allPastBookings;

        }

        public DataTable AllClients()
        {

            string sql = "SELECT c.Client_ID, p.FirstName, p.LastName, c.Business, c.ABN " + 
                         "FROM Client as c, Person as p " +
                         "WHERE c.Person_ID_Ref = p.Person_ID";

            _db = new SQLHelper();

            DataTable allClients = _db.ExecuteSQL(sql);

            return allClients;

        }
    }
}
