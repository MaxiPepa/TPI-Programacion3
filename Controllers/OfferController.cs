﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TPI_Programación3.Entities;
using TPI_Programación3.Models;
using TPI_Programación3.Repository;

namespace TPI_Programación3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfferController : Controller
    {
        private readonly IOfferRepository _offerRepository;

        public OfferController(IOfferRepository offerRepository)
        {
            _offerRepository = offerRepository;
        }

        [HttpGet]
        [Route("listOffer")]
        public IActionResult ListOffers()
        {
            List<Offer> offers = _offerRepository.GetAll();
            List<OfferResponse> offerList = new();


            foreach (var offer in offers)
            {
                OfferResponse response = new()
                {
                    Name = offer.Name,
                    Description = offer.Description,
                    Category = offer.Category,
                    ImgLink = offer.ImgLink,
                    CreatorEmail = offer.CreatorEmail,
                    PreferedItem = offer.PreferedItem
                };

                offerList.Add(response);
            }

            return Created("List of offers", offerList);
        }


        [HttpDelete]
        [Route("deleteOffer/{id}")]
        public IActionResult DeleteOffer(int id)
        {
            try
            {
                _offerRepository.Delete(id);
                return Ok("Succesfully deleted");
            }
            catch
            {
                return Problem("Offer not found");
            }
        }

        [HttpPost]
        [Route("addOffer")]
        public IActionResult AddOffer(AddOfferRequest dto)
        {
            try
            {
                List<Offer> offers = _offerRepository.GetAll();
                Offer offer = new(offers.Max(x => x.Id) + 1, dto.Name, dto.Description, dto.Category, dto.ImgLink, dto.CreatorEmail, dto.PreferedItem);

                OfferResponse response = new()
                {
                    Name = offer.Name,
                    Description = offer.Description,
                    Category = offer.Category,
                    ImgLink = offer.ImgLink,
                    CreatorEmail = offer.CreatorEmail,
                    PreferedItem = offer.PreferedItem
                };

                _offerRepository.Add(offer);
                return Created("Succesfully created!", response);
            }
            catch (Exception error)
            {
                return Problem(error.Message);
            }
        }

        [HttpPut]
        [Route("editOffer/{id}/{newValue}/{field}")]

        public IActionResult Edit(int id, string newValue, string field)
        {
            try
            {
                _offerRepository.Edit(id, newValue, field);
                return Ok("Succesfully edited");
            }
            catch
            {
                return Problem("Offer not found");
            }
        }
    }
}