﻿using SuperheroDirectory.Application.Dtos.Base;

namespace SuperheroDirectory.Application.Services.Abstractions
{
    public interface ISuperheroService
    {
        public Task<BaseResponse> SearchSuperhero(string superheroName);
    }
}