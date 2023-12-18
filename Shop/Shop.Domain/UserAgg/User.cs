using Common.Domain;
using Common.Domain.Exceptions;
using Shop.Domain.UserAgg.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.UserAgg
{
    public class User:AggregateRoot
    {
        public User(string name, string family, string phoneNumber, string email, string password, Gender gender)
        {
            Name = name;
            Family = family;
            PhoneNumber = phoneNumber;
            Email = email;
            Password = password;
            Gender = gender;
        }

        public string Name { get; private set; }

        public string Family { get; private set; }

        public string PhoneNumber { get; private set; }

        public string Email { get; private set; }

        public string Password { get; private set; }

        public Gender Gender { get; private set; }

        public List<UserAddress> Addresses { get; private set; }

        public List<Wallet> Wallets { get; private set; }

        public List<UserRole> Roles { get; private set; }
   

        public void Edit(string name, string family, string phoneNumber, string email, Gender gender)
        {
            Name = name;
            Family = family;
            PhoneNumber = phoneNumber;
            Email = email;
            Gender = gender;
        }

        public void AddAddress(UserAddress address)
        {
            address.UserId = Id;
            Addresses.Add(address);
        }

        public void EditAddress(UserAddress address)
        {
            var oldAddress = Addresses.FirstOrDefault(p => p.Id == address.Id);
            if (oldAddress == null) 
                 throw new NullOrEmptyDomainDataException("آدرس موجود نمی باشد");

            Addresses.Remove(oldAddress);
            Addresses.Add(address);
        }

        public void DeleteAddress(long addressId)
        {
            var oldAddress = Addresses.FirstOrDefault(p => p.Id == addressId);
            if (oldAddress == null) throw new NullOrEmptyDomainDataException("آدرسی برای حذف موجود نمی باشد");
            Addresses.Remove(oldAddress);
        }

        public void CharegWalet(Wallet  wallet)
        {
            Wallets.Add(wallet);
        }

        public void AddRoles(List<UserRole> roles)
        {
            Roles.Clear();
            Roles.AddRange(roles);
        }

        public void Guard(string phoneNumber , string email)
        {
            NullOrEmptyDomainDataException.CheckString(phoneNumber,nameof(phoneNumber));
            NullOrEmptyDomainDataException.CheckString(email, nameof(email));

            if (phoneNumber.Length != 11)
                throw new InvalidDomainDataException("شماره تلفن نامعتبر است");

            if (email.IsValidEmail() == false)
                throw new InvalidDomainDataException("ایمیل نامعتبر است");

        }
    }
}
