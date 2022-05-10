using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Firebase.Auth;
using MobiRice.DataHelper;
using MobiRice.Listeners;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MobiRice.Activities
{
    [Activity(Label = "signup_activity", MainLauncher = true)]
    public class signup_activity : Activity
    {
        Button btn_register;
        EditText usr_name;
        EditText usr_pwd;
        EditText usr_valpwd;
        EditText usr_phone;
        EditText usr_email;
        TextView login;

        TaskListeners taskListener = new TaskListeners();
        FirebaseAuth usrAuth = FirebaseDataHelper.GetFirebaseAuth();
        String _usrName, _usrPwd, _usrValpw, _usrPhone, _usrEmail;
        


        protected override void OnCreate(Bundle savedInstanceState)
        {


            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_register);
            
            //BIND ELEMENTS
            btn_register = FindViewById<Button>(Resource.Id.btn_register);
            usr_name = FindViewById<EditText>(Resource.Id.u_name);
            usr_email = FindViewById<EditText>(Resource.Id.u_email);
            usr_pwd = FindViewById<EditText>(Resource.Id.u_password);
            usr_valpwd = FindViewById<EditText>(Resource.Id.ValPassword);
            usr_phone = FindViewById<EditText>(Resource.Id.u_phone);
            login = FindViewById<TextView>(Resource.Id.goLogin);
            
            btn_register.Click += Btn_register_Click;
            login.Click += Login_Click;

        }

        private void Login_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(login_activity));
        }

        private void Btn_register_Click(object sender, EventArgs e)
        {
            _usrName = usr_name.Text;
            _usrEmail = usr_email.Text;
            _usrPhone = usr_phone.Text;
            _usrPwd = usr_pwd.Text;
            _usrValpw = usr_valpwd.Text;

            if(!_usrEmail.Contains("@"))
            {
                Toast.MakeText(Application.Context, "Enter a valid Email!", ToastLength.Short).Show();
                return;
            }
            else if(_usrPhone.Length < 11)
            {
                Toast.MakeText(Application.Context, "Phone must be 11 number", ToastLength.Short).Show();
                return;
            }else if(_usrName.Length < 3)
            {
                Toast.MakeText(Application.Context, "Enter a valid Name!", ToastLength.Short).Show();
                return;
            }else if (_usrPwd != _usrValpw) 
            {
                Toast.MakeText(Application.Context, "Password is not Match!", ToastLength.Short).Show();
                return;
            }else if(_usrName == null)
            {
                Toast.MakeText(Application.Context, "Please fill up the fields!", ToastLength.Short).Show();
                return;
            } else if(_usrEmail == null)
            {
                Toast.MakeText(Application.Context, "Please fill up the fields!", ToastLength.Short).Show();
                return;
            }
            else if (_usrPhone == null)
            {
                Toast.MakeText(Application.Context, "Please fill up the fields!", ToastLength.Short).Show();
                return;
            }
            else if(_usrPwd == null)
            {
                Toast.MakeText(Application.Context, "Please fill up the fields!", ToastLength.Short).Show();
                return;
            }
            else if(_usrValpw == null)
            {
                Toast.MakeText(Application.Context, "Please fill up the fields!", ToastLength.Short).Show();
                return;
            }
            
        }
    }
}