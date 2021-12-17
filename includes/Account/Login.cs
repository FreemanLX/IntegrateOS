using System;
using System.Drawing;
using FireSharp.Interfaces;
using FireSharp.Config;
using FireSharp.Response;

namespace IntegrateOS
{
    public partial class Login : MetroFramework.Forms.MetroForm
    {
        bool login = true;
        bool register = false;
        public Login() => InitializeComponent();

        IFirebaseClient firebaseClient;

        IFirebaseConfig firebaseConfig = new FirebaseConfig()
        {
			///you can make a firebase for you to connect, good luck
            AuthSecret = "",
            BasePath = ""
        };

        private void Login_Load(object sender, EventArgs e)
        {
             StyleManager = Themes.Generate;
             button1.BackColor = button2.BackColor = GenerateColors.Generate((int)Themes.MetroColor);
             button1.ForeColor = button2.ForeColor = Color.White;
             textBox3.BackColor =  textBox1.BackColor = textBox2.BackColor = Themes.GenerateTheme(Themes.MetroTheme);
             textBox1.ForeColor = textBox2.ForeColor = textBox3.ForeColor = Themes.GenerateTheme(!Themes.MetroTheme);
             label1.ForeColor = label2.ForeColor = label3.ForeColor = Themes.GenerateTheme(!Themes.MetroTheme);
        }


        private void Button1_Click(object sender, EventArgs e)
        {

            if (register == false)
            {
                Text = "Register";
                login = false;
                register = true;
                label3.Visible = textBox3.Visible = true;
            }
            else
            {
                if (Check == false)
                {
                    MessageBox.Show("All the fields must be completed");
                    return;
                }
                else
                {
                    try
                    {
                        firebaseClient = new FireSharp.FirebaseClient(firebaseConfig);
                        SetResponse setResponse = null;
                        if (textBox2.Text == textBox3.Text)
                        {
                            SHA256Encrypt encrypt = new SHA256Encrypt(textBox2.Text);
                            SHA256Encrypt username = new SHA256Encrypt(textBox1.Text);
                            Data.user = new User(textBox1.Text, encrypt.Get);
                            FirebaseResponse firebaseResponse = firebaseClient.Get(@"Users/" + username.Get + "_folder/");
                            User user = firebaseResponse.ResultAs<User>();
                            if(user != null)
                            {
                                MessageBox.Show("The account with your inserted email exists");
                                Data.user = null;
                                return;
                            }
                            else setResponse = firebaseClient.Set(@"Users/" + username.Get + "_folder/", Data.user);
                        }
                        MessageBox.Show("Successfully registered. You need to check your email!");
                    }

                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message);
                        Data.user = null;
                    }
                    finally
                    {
                        Close();
                    }
                }
                
            }
        }

        private bool Check => !(string.IsNullOrEmpty(textBox1.Text) && string.IsNullOrEmpty(textBox2.Text));

        private void Button2_Click(object sender, EventArgs e)
        {
            if (login == false)
            {
                Text = "Login";
                login = true;
                register = false;
                label3.Visible = textBox3.Visible = false;
            }
            else
            {
                if (Check == false)
                {
                    MessageBox.Show("All the fields must be completed");
                    return;
                }
                else
                {
                    try
                    {
                        firebaseClient = new FireSharp.FirebaseClient(firebaseConfig);
                        SHA256Encrypt encrypt = new SHA256Encrypt(textBox2.Text);
                        SHA256Encrypt username = new SHA256Encrypt(textBox1.Text);
                        FirebaseResponse firebaseResponse = firebaseClient.Get(@"Users/" + username.Get + "_folder/");
                        Data.user = firebaseResponse.ResultAs<User>();
                        if (Data.user != null)
                        {
                            if (Data.user.Encrypted_Password == encrypt.Get)
                            {
                                MessageBox.Show("Logged successfully!", "Message");
                            }
                            else
                            {
                                Data.user = null;
                            }
                        }
                        else
                        {
                            MessageBox.Show("The inserted account doesn't exist");
                        }
                    }

                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message);
                    }
                    finally
                    {
                        Close();
                    }
                }

            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
