using Common.Domain.Exceptions;
using Shop.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.Entities
{
    public class Banner
    {
        public Banner(string link, string imageName, BannerPossition pessition)
        {
            Guard(link, imageName);
            Link = link;
            ImageName = imageName;
            Pessition = pessition;
        }

        public void Edit(string link, string imageName, BannerPossition pessition)
        {
            Guard(link, imageName);
            Link = link;
            ImageName = imageName;
            Pessition = pessition;
        }

        public void Guard(string link , string imageName)
        {
            NullOrEmptyDomainDataException.CheckString(link, nameof(link));
            NullOrEmptyDomainDataException.CheckString(imageName, nameof(imageName));
        }


        public string Link { get; private set; }

        public string ImageName { get; private set; }

        public BannerPossition Pessition { get; set; }
    }
}
