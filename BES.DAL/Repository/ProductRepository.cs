using EBS.DAL.Interface;
using EBS.Models.Model.Products;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBS.DAL.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<ProductRepository> _logger;
        public ProductRepository(IUnitOfWork unitOfWork, ILogger<ProductRepository> logger)
            : base(unitOfWork, logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }
        //public async Task<IEnumerable<AssetDTO>> GetAssetsSearch(SearchAssetDTO dto)
        //{
        //    IEnumerable<AssetDTO> assets = new List<AssetDTO>();
        //    try
        //    {
        //        _logger.LogError("Getting assets");
        //        IQueryable<AssetDTO> assetsData = Enumerable.Empty<AssetDTO>().AsQueryable();

        //        if (!string.IsNullOrEmpty(dto.Query))
        //        {
        //            var query = dto.Query.ToLower();
        //            assetsData = (from asst in _unitOfWork.Context.Assets.Include("Manufacturer").Include("Files")
        //                          join aLk in _unitOfWork.Context.AssetLinks on asst.Id equals aLk.AssetId
        //                          into asLink
        //                          from assLink in asLink.DefaultIfEmpty()
        //                          join conts in _unitOfWork.Context.Contacts on assLink.ContactId equals conts.Id
        //                          into contact
        //                          from con in contact.DefaultIfEmpty()
        //                          join sites in _unitOfWork.Context.Sites on assLink.SiteId equals sites.Id
        //                          into site
        //                          from sit in site.DefaultIfEmpty()
        //                          join buildings in _unitOfWork.Context.Buildings on assLink.BuildingId equals buildings.Id
        //                          into building
        //                          from buld in building.DefaultIfEmpty()
        //                          join levels in _unitOfWork.Context.Levels on assLink.LevelId equals levels.Id
        //                          into level
        //                          from lvl in level.DefaultIfEmpty()
        //                          join areas in _unitOfWork.Context.Areas on assLink.AreaId equals areas.Id
        //                          into area
        //                          from are in area.DefaultIfEmpty()
        //                          join positions in _unitOfWork.Context.Positions on assLink.PositionId equals positions.Id
        //                          into position
        //                          from pos in position.DefaultIfEmpty()
        //                          where asst.CompanyId.Equals(dto.CompanyId) &&
        //                          asst.IsDeleted.Equals(false) &&
        //                            (
        //                             (asst.AssetType != null ? asst.AssetType : string.Empty).ToLower().Contains(query)
        //                             ||
        //                             (assLink.AssetUniqueId != null ? assLink.AssetUniqueId : string.Empty).ToLower().Equals(query)
        //                             ||
        //                             (asst.SubType != null ? asst.SubType : string.Empty).ToLower().Contains(query)
        //                             ||
        //                             (asst.IDNumber != null ? asst.IDNumber : string.Empty).ToLower().Contains(query)
        //                             ||
        //                             (asst.Name != null ? asst.Name : string.Empty).ToLower().Contains(query)
        //                             ||
        //                             (asst.Manufacturer.OrganisationName != null ? asst.Manufacturer.OrganisationName : string.Empty).ToLower().Contains(query)
        //                             ||
        //                             (asst.Status != null ? asst.Status : string.Empty).ToLower().Contains(query)
        //                             ||
        //                             (asst.ModelNo != null ? asst.ModelNo : string.Empty).ToLower().Contains(query)
        //                             ||
        //                             (con.AccountNo != null ? con.AccountNo : string.Empty).ToLower().Contains(query)
        //                             ||
        //                             (con.OrganisationName != null ? con.OrganisationName : string.Empty).ToLower().Contains(query)
        //                             ||
        //                             (sit.SiteName != null ? sit.SiteName : string.Empty).ToLower().Contains(query)
        //                             ||
        //                             (buld.Name != null ? buld.Name : string.Empty).ToLower().Contains(query)
        //                             ||
        //                             (lvl.Name != null ? lvl.Name : string.Empty).ToLower().Contains(query)
        //                             ||
        //                             (are.Name != null ? are.Name : string.Empty).ToLower().Contains(query)
        //                             ||
        //                             (pos.Name != null ? pos.Name : string.Empty).ToLower().Contains(query)
        //                             )
        //                          select new AssetDTO
        //                          {
        //                              Id = asst.Id,
        //                              IDNumber = asst.IDNumber,
        //                              Name = asst.Name,
        //                              Description = asst.Description,
        //                              DateOfManufacture = asst.DateOfManufacture,
        //                              ManufacturerName = asst.Manufacturer.OrganisationName,
        //                              ManufacturerId = asst.ManufacturerId,
        //                              ModelNo = asst.ModelNo,
        //                              PerpetualValue = asst.PerpetualValue,
        //                              WarrentyDateOfExpirey = asst.WarrentyDateOfExpirey,
        //                              TestSwitchCircuit = asst.TestSwitchCircuit,
        //                              LampType = asst.LampType,
        //                              IsMaintained = asst.IsMaintained,
        //                              Location = asst.Location,
        //                              TypeOfOutlet = asst.TypeOfOutlet,
        //                              TapType = asst.TapType,
        //                              DamperType = asst.DamperType,
        //                              SheetType = asst.SheetType,
        //                              TestDateTime = asst.TestDateTime,
        //                              AssetType = asst.AssetType,
        //                              CreatedTimeStamp = asst.CreatedTimeStamp,
        //                              UpdatedTimeStamp = asst.UpdatedTimeStamp,
        //                              IsDateOfManufacture = asst.IsDateOfManufacture,
        //                              IsWarrentyDateOfExpirey = asst.IsWarrentyDateOfExpirey,
        //                              SubType = asst.SubType,
        //                              Status = asst.Status,
        //                              Image1Byte = _unitOfWork.Context.Files.Where(k => k.AssetId.Equals(asst.Id) && k.IsDeleted.Equals(false) && k.AttachmentType.Equals(Enums.ImageAttachmentType.Image1.ToString())).FirstOrDefault().Data,
        //                              Image1Type = _unitOfWork.Context.Files.Where(k => k.AssetId.Equals(asst.Id) && k.IsDeleted.Equals(false) && k.AttachmentType.Equals(Enums.ImageAttachmentType.Image1.ToString())).FirstOrDefault().AttachmentType,
        //                              Image2Byte = _unitOfWork.Context.Files.Where(k => k.AssetId.Equals(asst.Id) && k.IsDeleted.Equals(false) && k.AttachmentType.Equals(Enums.ImageAttachmentType.Image2.ToString())).FirstOrDefault().Data,
        //                              Image2Type = _unitOfWork.Context.Files.Where(k => k.AssetId.Equals(asst.Id) && k.IsDeleted.Equals(false) && k.AttachmentType.Equals(Enums.ImageAttachmentType.Image2.ToString())).FirstOrDefault().AttachmentType,
        //                              ExtinguisherType = asst.ExtinguisherType,
        //                              TotalAssets = _unitOfWork.Context.AssetLinks.Where(k => k.AssetId == asst.Id && k.IsDeleted.Equals(false)).Count(),
        //                              NonWorkingAssets = _unitOfWork.Context.Remediations.Where(k => k.assetLink.AssetId == asst.Id && k.RemediationStatus != Enums.Remediation.RemediationStatus.Fixed.ToString()).Count(),
        //                          }).Distinct();
        //        }
        //        else
        //        {
        //            assetsData = (from asst in _unitOfWork.Context.Assets.Include("Manufacturer").Include("Files")
        //                          where asst.CompanyId.Equals(dto.CompanyId) &&
        //                          asst.IsDeleted.Equals(false)
        //                          select new AssetDTO
        //                          {
        //                              Id = asst.Id,
        //                              IDNumber = asst.IDNumber,
        //                              Name = asst.Name,
        //                              Description = asst.Description,
        //                              DateOfManufacture = asst.DateOfManufacture,
        //                              ManufacturerName = asst.Manufacturer.OrganisationName,
        //                              ManufacturerId = asst.ManufacturerId,
        //                              ModelNo = asst.ModelNo,
        //                              PerpetualValue = asst.PerpetualValue,
        //                              WarrentyDateOfExpirey = asst.WarrentyDateOfExpirey,
        //                              TestSwitchCircuit = asst.TestSwitchCircuit,
        //                              LampType = asst.LampType,
        //                              IsMaintained = asst.IsMaintained,
        //                              Location = asst.Location,
        //                              TypeOfOutlet = asst.TypeOfOutlet,
        //                              DamperType = asst.DamperType,
        //                              TapType = asst.TapType,
        //                              SheetType = asst.SheetType,
        //                              TestDateTime = asst.TestDateTime,
        //                              AssetType = asst.AssetType,
        //                              IsDateOfManufacture = asst.IsDateOfManufacture,
        //                              IsWarrentyDateOfExpirey = asst.IsWarrentyDateOfExpirey,
        //                              SubType = asst.SubType,
        //                              CreatedTimeStamp = asst.CreatedTimeStamp,
        //                              UpdatedTimeStamp = asst.UpdatedTimeStamp,
        //                              Status = asst.Status,
        //                              Image1Byte = _unitOfWork.Context.Files.Where(k => k.AssetId.Equals(asst.Id) && k.IsDeleted.Equals(false) && k.AttachmentType.Equals(Enums.ImageAttachmentType.Image1.ToString())).FirstOrDefault().Data,
        //                              Image1Type = _unitOfWork.Context.Files.Where(k => k.AssetId.Equals(asst.Id) && k.IsDeleted.Equals(false) && k.AttachmentType.Equals(Enums.ImageAttachmentType.Image1.ToString())).FirstOrDefault().AttachmentType,
        //                              Image2Byte = _unitOfWork.Context.Files.Where(k => k.AssetId.Equals(asst.Id) && k.IsDeleted.Equals(false) && k.AttachmentType.Equals(Enums.ImageAttachmentType.Image2.ToString())).FirstOrDefault().Data,
        //                              Image2Type = _unitOfWork.Context.Files.Where(k => k.AssetId.Equals(asst.Id) && k.IsDeleted.Equals(false) && k.AttachmentType.Equals(Enums.ImageAttachmentType.Image2.ToString())).FirstOrDefault().AttachmentType,
        //                              ExtinguisherType = asst.ExtinguisherType,
        //                              TotalAssets = _unitOfWork.Context.AssetLinks.Where(k => k.AssetId == asst.Id && k.IsDeleted.Equals(false)).Count(),
        //                              NonWorkingAssets = _unitOfWork.Context.Remediations.Where(k => k.assetLink.AssetId.Equals(asst.Id) && k.RemediationStatus != Enums.Remediation.RemediationStatus.Fixed.ToString()).Count(),
        //                          });
        //        }

        //        if ((int)dto.FilterName > 0 && !string.IsNullOrEmpty(dto.FilterValue) && !dto.FilterValue.Equals("AssetUniqueId"))
        //        {
        //            if (dto.FilterName == Enums.AssetMaterialsColumn.Type)
        //            {
        //                assetsData = assetsData.Where(u => u.AssetType.Contains(dto.FilterValue));
        //            }
        //        }
        //        dto.TotalRecords = assetsData.Count();
        //        dto.TotalFilteredRecords = assetsData.Count();
        //        if ((int)dto.Column > 0)
        //        {
        //            if (dto.Order == Enums.Order.asc.ToString() && dto.Column != Enums.AssetMaterialsColumn.Image)
        //            {
        //                if (dto.Column == Enums.AssetMaterialsColumn.Type)
        //                {
        //                    assetsData = assetsData.OrderBy(u => u.AssetType).Skip(dto.Start).Take(dto.PageSize);
        //                }
        //                if (dto.Column == Enums.AssetMaterialsColumn.SubType)
        //                {
        //                    assetsData = assetsData.OrderBy(u => u.SubType).Skip(dto.Start).Take(dto.PageSize);
        //                }
        //                if (dto.Column == Enums.AssetMaterialsColumn.Id)
        //                {
        //                    assetsData = assetsData.OrderBy(u => u.IDNumber).Skip(dto.Start).Take(dto.PageSize);
        //                }
        //                if (dto.Column == Enums.AssetMaterialsColumn.Name)
        //                {
        //                    assetsData = assetsData.OrderBy(u => u.Name).Skip(dto.Start).Take(dto.PageSize);
        //                }
        //                if (dto.Column == Enums.AssetMaterialsColumn.Manufacturer)
        //                {
        //                    assetsData = assetsData.OrderBy(u => u.ManufacturerName).Skip(dto.Start).Take(dto.PageSize);
        //                }
        //                if (dto.Column == Enums.AssetMaterialsColumn.Status)
        //                {
        //                    assetsData = assetsData.OrderBy(u => u.Status).Skip(dto.Start).Take(dto.PageSize);
        //                }
        //                if (dto.Column == Enums.AssetMaterialsColumn.ModelNo)
        //                {
        //                    assetsData = assetsData.OrderBy(u => u.ModelNo).Skip(dto.Start).Take(dto.PageSize);
        //                }
        //                if (dto.Column == Enums.AssetMaterialsColumn.UpdatedTimeStamp)
        //                {
        //                    assetsData = assetsData.OrderBy(u => u.UpdatedTimeStamp).Skip(dto.Start).Take(dto.PageSize);
        //                }
        //            }
        //            else if (dto.Order == Enums.Order.desc.ToString() && dto.Column != Enums.AssetMaterialsColumn.Image)
        //            {
        //                if (dto.Column == Enums.AssetMaterialsColumn.Type)
        //                {
        //                    assetsData = assetsData.OrderByDescending(u => u.AssetType).Skip(dto.Start).Take(dto.PageSize);
        //                }
        //                if (dto.Column == Enums.AssetMaterialsColumn.SubType)
        //                {
        //                    assetsData = assetsData.OrderByDescending(u => u.SubType).Skip(dto.Start).Take(dto.PageSize);
        //                }
        //                if (dto.Column == Enums.AssetMaterialsColumn.Id)
        //                {
        //                    assetsData = assetsData.OrderByDescending(u => u.IDNumber).Skip(dto.Start).Take(dto.PageSize);
        //                }
        //                if (dto.Column == Enums.AssetMaterialsColumn.Name)
        //                {
        //                    assetsData = assetsData.OrderByDescending(u => u.Name).Skip(dto.Start).Take(dto.PageSize);
        //                }
        //                if (dto.Column == Enums.AssetMaterialsColumn.Manufacturer)
        //                {
        //                    assetsData = assetsData.OrderByDescending(u => u.ManufacturerName).Skip(dto.Start).Take(dto.PageSize);
        //                }
        //                if (dto.Column == Enums.AssetMaterialsColumn.Status)
        //                {
        //                    assetsData = assetsData.OrderByDescending(u => u.Status).Skip(dto.Start).Take(dto.PageSize);
        //                }
        //                if (dto.Column == Enums.AssetMaterialsColumn.ModelNo)
        //                {
        //                    assetsData = assetsData.OrderByDescending(u => u.ModelNo).Skip(dto.Start).Take(dto.PageSize);
        //                }
        //                if (dto.Column == Enums.AssetMaterialsColumn.UpdatedTimeStamp)
        //                {
        //                    assetsData = assetsData.OrderByDescending(u => u.UpdatedTimeStamp).Skip(dto.Start).Take(dto.PageSize);
        //                }
        //            }
        //        }
        //        else
        //        {
        //            assetsData = assetsData.OrderByDescending(u => u.UpdatedTimeStamp).Skip(dto.Start).Take(dto.PageSize);
        //        }

        //        dto.Records = assetsData;
        //        assets = dto.Records;
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError(ex, ex.Message, ex.InnerException, ex.InnerException != null ? ex.InnerException.Message : string.Empty);
        //        throw new Exception(ex.Message, ex.InnerException);
        //    }

        //    _logger.LogError("Returning Bookings:" + assets);
        //    return await Task.FromResult(assets);
        //}
    }
}
