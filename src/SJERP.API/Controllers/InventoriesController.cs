using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SJERP.API.DTOs.Inventory;
using SJERP.API.DTOs.Product;
using SJERP.Domain.Interfaces;
using SJERP.Domain.Models;
using SJERP.Domain.Models.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SJERP.API.Controllers
{
    [Route("api/[controller]")]
    public class InventoriesController : MainController
    {
        private readonly IInventoryService _inventoryService;
        private readonly IInventoryDetailService _inventoryDetailService;
        private readonly IMapper _mapper;

        public InventoriesController(IMapper mapper, IInventoryService inventoryService, IInventoryDetailService inventoryDetailService)
        {
            _mapper = mapper;
            _inventoryService = inventoryService;
            _inventoryDetailService = inventoryDetailService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var inventories = await _inventoryService.GetAll();

            return Ok(_mapper.Map<IEnumerable<InventoryResultDto>>(inventories));
        }

        [HttpGet]
        [Route("get-all-sales")]
        public async Task<IActionResult> GetAllSales()
        {
            var inventories = await _inventoryService.GetAllSales();

            return Ok(_mapper.Map<IEnumerable<InventoryResultDto>>(inventories));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var inventory = await _inventoryService.GetById(id);

            if (inventory == null) return NotFound();

            return Ok(_mapper.Map<InventoryResultDto>(inventory));
        }

        [HttpGet]
        [Route("get-inventory-by-category/{categoryId}")]
        public async Task<IActionResult> GetInventoryByCategory(int categoryId)
        {
            var inventories = await _inventoryService.GetInventoryByCategory(categoryId);

            if (!inventories.Any()) return NotFound();

            return Ok(_mapper.Map<IEnumerable<InventoryResultDto>>(inventories));
        }

        [HttpPost]
        public async Task<IActionResult> Add(InventoryAddDto inventoryDto)
        {
            if (!ModelState.IsValid) return BadRequest(new { message = "Model State is not valid" });

            var inventory = _mapper.Map<Inventory>(inventoryDto);
            var inventoryResult = await _inventoryService.Add(inventory);

            if(inventoryResult != null && inventoryResult.Id > 0)
            {
                foreach (InventoryDetail detail in inventoryDto.InventoryDetail)
                {
                    var detailmap = _mapper.Map<InventoryDetail>(detail);
                    detailmap.InventoryId = inventoryResult.Id;
                    var detailmapResult = await _inventoryDetailService.Add(detailmap);
                }
            }


            if (inventoryResult == null) return NotFound(new { message = "Record already exisit!!!"});

            return Ok(_mapper.Map<InventoryResultDto>(inventoryResult));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, InventoryEditDto inventoryDto)
        {
            if (id != inventoryDto.Id) return BadRequest();

            if (!ModelState.IsValid) return BadRequest();

            await _inventoryService.Update(_mapper.Map<Inventory>(inventoryDto));

            return Ok(inventoryDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var inventory = await _inventoryService.GetById(id);
            if (inventory == null) return NotFound();

            await _inventoryService.Remove(inventory);

            return Ok();
        }

        //[Route("search/{inventoryName}")]
        //[HttpGet]
        //public async Task<ActionResult<List<Inventory>>> Search(string inventoryName)
        //{
        //    var inventories = _mapper.Map<List<Inventory>>(await _inventoryService.Search(inventoryName));

        //    if (inventories == null || inventories.Count == 0) return NotFound("None inventory was founded");

        //    return Ok(inventories);
        //}

        [Route("search-inventory/{searchedValue}")]
        [HttpGet]
        public async Task<ActionResult<List<Inventory>>> SearchProductWithCategory(string searchedValue)
        {
            var inventories = _mapper.Map<List<Inventory>>(await _inventoryService.SearchInventoryfromStock(searchedValue));

            if (!inventories.Any()) return NotFound("None inventory was founded");

            return Ok(_mapper.Map<IEnumerable<InventoryResultDto>>(inventories));
        }
    }

}
