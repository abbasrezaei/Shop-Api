using Common.Domain;
using Common.Domain.Exceptions;
using Shop.Domain.UserAgg.Enum;
using Shop.Domain.UserAgg.Services;

namespace Shop.Domain.UserAgg
{
    public class User:AggregateRoot
    {
        public User(string name, string family, string phoneNumber, string email, string password,
            Gender gender, IDomainUserService domainServcie)
        {
            Guard(phoneNumber, email, domainServcie);
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
   
        public static User RegsiterUser(string email,string phonNumber,string password, IDomainUserService domainServcie)
        {
            return new ("","",email,phonNumber,password, Gender.None, domainServcie);
        }


        public void Edit(string name, string family, string phoneNumber, string email,
            Gender gender,IDomainUserService domainServcie)
        {
            Guard(phoneNumber, email, domainServcie);
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
            wallet.UserId = Id;
            Wallets.Add(wallet);
        }

        public void SetRoles(List<UserRole> roles)
        {
            roles.ForEach(p => p.UserId = Id );
            Roles.Clear();
            Roles.AddRange(roles);
        }

        public void Guard(string phoneNumber , string email,IDomainUserService domainService)
        {
            NullOrEmptyDomainDataException.CheckString(phoneNumber,nameof(phoneNumber));
            NullOrEmptyDomainDataException.CheckString(email, nameof(email));

            if (phoneNumber.Length != 11)
                throw new InvalidDomainDataException("شماره تلفن نامعتبر است");

            if (email.IsValidEmail() == false)
                throw new InvalidDomainDataException("ایمیل نامعتبر است");

            if (phoneNumber != PhoneNumber)
                if (domainService.PhoneNumberIsExist(phoneNumber))
                    throw new InvalidDomainDataException("شماره موبایل تکراری است");

            if (email != Email)
                if (domainService.IsEmailExist(email))
                    throw new InvalidDomainDataException("ایمیل تکراری است");
        }
    }
}
