﻿using Library.Domain.Model;

namespace Library.Application.Models.Genders.Request
{
    public class GenderFilterRequest
    {
        public string Name { get; set; } = string.Empty;
        public int? PageNumber { get; set; } = null;
        public int? PageSize { get; set; } = null;

        public static implicit operator GenderFilterModel(GenderFilterRequest model) => new()
        {
            Name = model.Name,
            PageNumber = (int)(model.PageNumber == null ? 1 : model.PageNumber),
            PageSize = (int)(model.PageSize == null ? 10 : model.PageSize),
        };
    }
}
