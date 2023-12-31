﻿using Common.Domain;
using Common.Domain.Exceptions;

namespace Shop.Domain.UserAgg
{
    public class UserAddress : BaseEntity
    {
        public UserAddress(string shire, string city, string postalCode,string postalAddress , string phoneNumber, string name, string family, string nationalCode)
        {
            Guard(shire, city, postalCode, postalAddress, phoneNumber, name, family, nationalCode);
            Shire = shire;
            City = city;
            PostalCode = postalCode;
            PostalAddress = postalAddress;
            PhoneNumber = phoneNumber;
            Name = name;
            Family = family;
            NationalCode = nationalCode;
            ActiveAddress = false;

        }

        public long UserId { get; internal set; }

        public string Shire { get; private set; }

        public string City { get; private set; }

        public string PostalCode { get; private set; }

        public string PostalAddress { get; set; }

        public string PhoneNumber { get; private set; }

        public string Name { get; private set; }

        public string Family { get; set; }

        public string NationalCode { get; private set; }

        public bool ActiveAddress { get; private set; }

        public  void Edit (string shire, string city, string postalCode,string postalAddress, string phoneNumber, string name, string family, string nationalCode)
        {
            Guard(shire, city, postalCode, postalAddress, phoneNumber, name, family, nationalCode);
            Shire = shire;
            City = city;
            PostalCode = postalCode;
            PostalAddress= postalAddress;
            PhoneNumber = phoneNumber;
            Name = name;
            Family = family;
            NationalCode = nationalCode;
        }

        public void SetActive() { ActiveAddress = true; }

        public void Guard(string shire, string city, string postalCode,string postalAddress , string phoneNumber, string name, string family, string nationalCode) {

            NullOrEmptyDomainDataException.CheckString(shire, nameof(Shire));
            NullOrEmptyDomainDataException.CheckString(city, nameof(City));
            NullOrEmptyDomainDataException.CheckString(postalCode, nameof(PostalCode));
            NullOrEmptyDomainDataException.CheckString(postalAddress, nameof(PostalAddress));
            NullOrEmptyDomainDataException.CheckString(phoneNumber, nameof(PhoneNumber));
            NullOrEmptyDomainDataException.CheckString(name, nameof(Name)); 
            NullOrEmptyDomainDataException.CheckString(family, nameof(Family));
            NullOrEmptyDomainDataException.CheckString(nationalCode, nameof(NationalCode));


            if (IranianNationalIdChecker.IsValid(nationalCode) == false)
                throw new InvalidDomainDataException("کد ملی نامعتبر است");
        }


    }
}
