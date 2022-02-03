using AutoMapper;
using MovieStore.Entities;
using MovieStore.Operations.MovieOperations.Commands.CreateMovie;
using MovieStore.Operations.MovieOperations.Queries.GetMovieDetails;
using MovieStore.Operations.MovieOperations.Queries.GetMovies;
using MovieStore.Operations.SellingOperations.GetSellings;
using MovieStore.Operations.SellingOperations.SellMovie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static MovieStore.Operations.ActorOperations.Commands.CreateActorCommand;
using static MovieStore.Operations.ActorOperations.Queries.GetActorDetails.GetActorDetailsQuery;
using static MovieStore.Operations.ActorOperations.Queries.GetActors.GetActorsQuery;
using static MovieStore.Operations.DirectorOperations.Commands.CreateDirector.CreateDirectorCommand;
using static MovieStore.Operations.DirectorOperations.Queries.GetDirectorDetails.GetDirectorDetailsQuery;
using static MovieStore.Operations.DirectorOperations.Queries.GetDirectors.GetDirectorsQuery;

namespace MovieStore.Common
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateActorModel, Actor>();           
            CreateMap<Actor, GetActorModel>();           
            CreateMap<Actor, ActorDetailModel>();           
            CreateMap<CreateDirectorModel, Director>();           
            CreateMap<Director, GetDirectorModel>();           
            CreateMap<Director, DirectorViewModel>();           
            CreateMap<CreateMovieModel, Movie>();           
            CreateMap<Movie, GetMovieModel>();           
            CreateMap<Movie, MovieViewModel>();           
            CreateMap<SellMovieModel, Selling>();           
            CreateMap<Selling, GetSellingsModel>();           
        }        
    }
}
