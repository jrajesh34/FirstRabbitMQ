using AutoMapper;
using EOM.Kernel.Infrastructure.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace FirstRabbitMQ
{
    public static class AddressFieldType
    {
        public const string State = "State";
        public const string City = "City";
        public const string Address1 = "Address1";
        public const string Address2 = "Address2";
        public const string PostalCode = "PostalCode";
    }
    public class AddressConfigSettings
    {
        public int AddressConfigSettingId { get; set; }
        public int AddressFieldTypeId { get; set; }
        public int CountryId { get; set; }
        [StringLength(50)]
        public string CountryName { get; set; }
        [StringLength(50)]
        public string DisplayLabel { get; set; }
        public bool IsActiveFlag { get; set; }
        public bool IsRequiredFlag { get; set; }
        public bool IsDataListFlag { get; set; }
        public bool IsDeletedFlag { get; set; }
        public int DisplayOrder { get; set; }
        public bool IsUsedInDisplay { get; set; }
        public int RowPositionDisplay { get; set; }
        public int ColumnPositionDisplay { get; set; }
    }

    public class AddressConfigSettingsDto
    {
        public int AddressConfigSettingId { get; set; }
        public int AddressFieldTypeId { get; set; }
        public int CountryId { get; set; }
        private string field;
        public string Field
        {
            get
            {
                switch (AddressFieldTypeId)
                {
                    case 1:
                        field = AddressFieldType.State;
                        break;
                    case 2:
                        field = AddressFieldType.City;
                        break;
                    case 3:
                        field = AddressFieldType.Address1;
                        break;
                    case 4:
                        field = AddressFieldType.Address2;
                        break;
                    case 5:
                        field = AddressFieldType.PostalCode;
                        break;
                    default:
                        return string.Empty;
                }
                return field;
            }
            set { field = value; }
        }
        public string CountryName { get; set; }
        public string DisplayLabel { get; set; }
        public bool IsActiveFlag { get; set; }
        public bool IsRequiredFlag { get; set; }
        public bool IsDataListFlag { get; set; }
        public bool IsDeletedFlag { get; set; }
        public int DisplayOrder { get; set; }
        public bool IsUsedInDisplay { get; set; }
        public int RowPositionDisplay { get; set; }
        public int ColumnPositionDisplay { get; set; }
    }

    public class MapperService
    {
        public TDestination Map<TSource, TDestination>(TSource source, TDestination destination)
        {
            var tempMapperConfig = new MapperConfiguration((x) =>
            {
                x.CreateMap(typeof(TSource), typeof(TDestination));
            });
            var mapper = tempMapperConfig.CreateMapper();
            return mapper.Map(source, destination);
        }
    }

        public static class LookupTypeValue
    {
        public const string ItemTaxAuthority = "Item Tax Authority Defaults";
        public const string AddressConfiguration = "Address Configuration";
        public const string StateLabel = "State";
        public const string CityLabel = "City";
        public const string Address1Label = "Address 1";
        public const string Address2Label = "Address 2";
        public const string PostalCodeLabel = "Postal code";
    }

    public enum AddressField
    {
        State,
        City,
        Address1,
        Address2,
        PostalCode
    }

    public partial class Form2 : Form
    {
        private readonly IEncryptionService encryptionService;
        public Form2()
        {
            InitializeComponent();

            // this.encryptionService = encryptionService;
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            try
            {
                var decryptedExtraData = encryptionService.DecryptData("OlnPCTnaPqo1JgzdCGKzETOsWX999rU5FmC0AWR1PG8JqmfAIownj3QWhE2dzqF/",
                    "smtmlWEp0FWzFeP/va4UCtLM2mfKwApPUcnkAg6D9lR3q6oMZnVhiyIFlUHhU4Fo");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var listObjects = GetDefaultAddressConfigsettings();
            var output = JsonConvert.SerializeObject(listObjects);

            listObjects.Find(x => x.IsActiveFlag = true);

            listObjects = null;

            foreach(var address in listObjects)
            {

            }

            JavaScriptSerializer ser = new JavaScriptSerializer();
            List<AddressConfigSettings> lst = ser.Deserialize<List<AddressConfigSettings>>(output);

            var addressConfigSettingsDtos = new List<AddressConfigSettingsDto>();
            addressConfigSettingsDtos = new MapperService().Map(listObjects, new List<AddressConfigSettingsDto>());

            //addressConfigSettingsDtos = mapperService.Map(listObjects, new List<AddressConfigSettingsDto>());

            var test = string.Format(@"{0}", "123");

            StringBuilder liElement = new StringBuilder();
            foreach (var addressConfig in listObjects)
            {
                liElement.AppendLine(string.Format(@"<li id = ""{0}""  data-name = ""{1}"" data-cat = ""Address"" class=""ui-sortable-handle"" 
                                       <span style = ""display: inline-block; width: 290px;"" > {1} </span>
                                       <a onclick='displayFields(this)'> Settings</a></li>", "lst" + "X", "Y"));
            }
            //DataTable dt = new DataTable(); DataRow dr = null;
            //dt.Columns.Add(new DataColumn("ID", typeof(int)));
            //dt.Columns.Add(new DataColumn("FirstName", typeof(string)));
            //dt.Columns.Add(new DataColumn("LastName", typeof(string)));
            //dt.Columns.Add(new DataColumn("MiddleName", typeof(string)));

                ////create new row
                //dr = dt.NewRow();
                ////add values to each rows
                //dr["ID"] = 1;
                //dr["FirstName"] = "Vincent";
                //dr["LastName"] = "Durano";
                //dr["MiddleName"] = null;
                ////add the row to DataTable
                //dt.Rows.Add(dr);

                //DataView dataView = new DataView();
                //DataRowView dRowView = dr.Table.DefaultView.AddNew();
                ////dRowView["CustomerID"] = "J7COM"; dRowView["CompanyName"] = "J7 Company"; dRowView["Country"] = "UK"; dRowView.EndEdit();

                //DataRowView selecRow = dt.DefaultView.Cast<DataRowView>().FirstOrDefault(a => a.Row == dr);

                //if (!string.IsNullOrEmpty(selecRow["MiddleName"].ToString()))
                //{

                //}

                //StringBuilder sb = new StringBuilder();

                //string test = "";
                //var result = test.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Length;

                //var msg = string.Format("{0} {1}", ("Error Occured:"), "XYZ");
                //lblNotes.Text = msg;
        }

        private List<AddressConfigSettings> GetDefaultAddressConfigsettings()
        {
            var addressConfigSettings = new List<AddressConfigSettings>();

            var addressConfig = new AddressConfigSettings()
            {
                AddressFieldTypeId = 1,
                AddressConfigSettingId = 0,
                CountryName = string.Empty,
                DisplayLabel = LookupTypeValue.StateLabel,
                IsActiveFlag = true,
                IsRequiredFlag = true,
                IsDataListFlag = true,
                IsDeletedFlag = false,
                DisplayOrder = 1,
            };
            addressConfigSettings.Add(addressConfig);
            addressConfig = new AddressConfigSettings()
            {
                AddressFieldTypeId = 2,
                AddressConfigSettingId = 0,
                CountryName = string.Empty,
                DisplayLabel = LookupTypeValue.CityLabel,
                IsActiveFlag = true,
                IsRequiredFlag = true,
                IsDataListFlag = true,
                IsDeletedFlag = false,
                DisplayOrder = 2,
            };
            addressConfigSettings.Add(addressConfig);
            addressConfig = new AddressConfigSettings()
            {
                AddressFieldTypeId = 3,
                AddressConfigSettingId = 0,
                CountryName = string.Empty,
                DisplayLabel = LookupTypeValue.Address1Label,
                IsActiveFlag = true,
                IsRequiredFlag = true,
                IsDataListFlag = false,
                IsDeletedFlag = false,
                DisplayOrder = 3,
            };
            addressConfigSettings.Add(addressConfig);
            addressConfig = new AddressConfigSettings()
            {
                AddressFieldTypeId = 4,
                AddressConfigSettingId = 0,
                CountryName = string.Empty,
                DisplayLabel = LookupTypeValue.Address2Label,
                IsActiveFlag = true,
                IsRequiredFlag = true,
                IsDataListFlag = true,
                IsDeletedFlag = false,
                DisplayOrder = 4,
            };
            addressConfigSettings.Add(addressConfig);
            addressConfig = new AddressConfigSettings()
            {
                AddressFieldTypeId = 5,
                AddressConfigSettingId = 0,
                CountryName = string.Empty,
                DisplayLabel = LookupTypeValue.PostalCodeLabel,
                IsActiveFlag = true,
                IsRequiredFlag = true,
                IsDataListFlag = false,
                IsDeletedFlag = false,
                DisplayOrder = 5,
            };
            addressConfigSettings.Add(addressConfig);
            return addressConfigSettings;
        }

        private List<AddressConfigSettingsDto> GetDefaultAddressConfigsettingsDto()
        {
            var addressConfigSettings = new List<AddressConfigSettingsDto>();

            var addressConfig = new AddressConfigSettingsDto()
            {
                AddressFieldTypeId = 1,
                Field = LookupTypeValue.StateLabel,
                AddressConfigSettingId = 0,
                CountryName = string.Empty,
                DisplayLabel = LookupTypeValue.StateLabel,
                IsActiveFlag = true,
                IsRequiredFlag = true,
                IsDataListFlag = true,
                IsDeletedFlag = false,
                DisplayOrder = 1,
            };
            addressConfigSettings.Add(addressConfig);
            addressConfig = new AddressConfigSettingsDto()
            {
                AddressFieldTypeId = 2,
                Field = LookupTypeValue.CityLabel,
                AddressConfigSettingId = 0,
                CountryName = string.Empty,
                DisplayLabel = LookupTypeValue.CityLabel,
                IsActiveFlag = true,
                IsRequiredFlag = true,
                IsDataListFlag = true,
                IsDeletedFlag = false,
                DisplayOrder = 2,
            };
            addressConfigSettings.Add(addressConfig);
            addressConfig = new AddressConfigSettingsDto()
            {
                AddressFieldTypeId = 3,
                Field = LookupTypeValue.Address1Label,
                AddressConfigSettingId = 0,
                CountryName = string.Empty,
                DisplayLabel = LookupTypeValue.Address1Label,
                IsActiveFlag = true,
                IsRequiredFlag = true,
                IsDataListFlag = false,
                IsDeletedFlag = false,
                DisplayOrder = 3,
            };
            addressConfigSettings.Add(addressConfig);
            addressConfig = new AddressConfigSettingsDto()
            {
                AddressFieldTypeId = 4,
                Field = LookupTypeValue.Address2Label,
                AddressConfigSettingId = 0,
                CountryName = string.Empty,
                DisplayLabel = LookupTypeValue.Address2Label,
                IsActiveFlag = true,
                IsRequiredFlag = true,
                IsDataListFlag = true,
                IsDeletedFlag = false,
                DisplayOrder = 4,
            };
            addressConfigSettings.Add(addressConfig);
            addressConfig = new AddressConfigSettingsDto()
            {
                AddressFieldTypeId = 5,
                Field = LookupTypeValue.PostalCodeLabel,
                AddressConfigSettingId = 0,
                CountryName = string.Empty,
                DisplayLabel = LookupTypeValue.PostalCodeLabel,
                IsActiveFlag = true,
                IsRequiredFlag = true,
                IsDataListFlag = false,
                IsDeletedFlag = false,
                DisplayOrder = 5,
            };
            addressConfigSettings.Add(addressConfig);
            return addressConfigSettings;
        }

        private void test()
        {
            var myCustomer = new { id= 1, fName= "Rajesh", lName= "Jeyapaul"};

            List<dynamic> dynamicList = new List<dynamic>();
            dynamicList.Add(new { Name = "Krishna", Phones = new[] { "555-555-5555", "666-666-6666" } });
        }
    }
}
