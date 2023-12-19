﻿using Common.Domain;
using Common.Domain.Exceptions;

namespace Shop.Domain.ProductAgg
{
    public class ProductImage : BaseEntity
    {
        public ProductImage(string imageName, string sequence)
        {
            NullOrEmptyDomainDataException.CheckString(imageName,nameof(imageName));
            ImageName = imageName;
            Sequence = sequence;
        }
         
        public long ProductId { get; internal set; }

        public string ImageName { get; private set; }

        public string Sequence { get; private set; }

    }
}
