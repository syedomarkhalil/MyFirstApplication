﻿using MyFirstApplication.Models;

namespace MyFirstApplication.Services
{
    public interface ITvShowService
    {
        public Task<List<TvShow>> GetTvShows();
    }
}