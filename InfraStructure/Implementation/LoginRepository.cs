using Domain_Models;
using InfraStructure.Interfaces;
using InfraStructure.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;


namespace InfraStructure.Implementation
{
    public class LoginRepository: ILoginRepository
    {
        private readonly IGenericRepository _genericRepository;
        private readonly RealEstateContext db;
        public LoginRepository(IGenericRepository genericRepository, RealEstateContext db)
        {
            _genericRepository = genericRepository;
            this.db = db;

        }

        public string GenerateOTP()
        {
            Random rnd = new Random();
            return rnd.Next(1000, 10000).ToString();
        }

        // Method to send OTP to email address

        public bool SendOTP(string email, string otp)

        {
            try
            {
                // Create MailMessage object
                MailMessage message = new MailMessage();
                message.From = new MailAddress("irfanilm524@gmail.com"); // Sender's email address
                message.To.Add(email); // Recipient's email address
                message.Subject = "OTP for Sign Up";
                message.Body = $"Your OTP for sign up is: {otp}";

                // Configure SMTP client for Gmail
                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("irfanilm524@gmail.com", "ordv rayr hjdn mjnm");
                smtp.EnableSsl = true;


                // Send the email
                smtp.Send(message);

                // Dispose SmtpClient to release resources
                smtp.Dispose();

                return true;
            }
            catch (Exception ex)
            {
                // Handle exception (e.g., log error)
                Console.WriteLine($"Failed to send email: {ex.Message}");
                return false;
            }

           
        }

        public OwnerVm Login(LoginVm model)
        {
            var result = db.Owners.Where(p => p.Email == model.Email && p.Password == model.Password).FirstOrDefault();
            if (result != null)
            {
                var ownerModel= new OwnerVm() { 
                    Id = result.Id,
                    FirstName = result.FirstName,
                    LastName = result.LastName,
                    Email = result.Email,
                    Contact= result.Contact,
                    Password= result.Password,
                };
                return ownerModel;
            }
            else
            {
                return null;
            }
        }

    }
}
