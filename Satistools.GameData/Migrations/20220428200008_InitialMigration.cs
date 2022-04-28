using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Satistools.GameData.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BuildableManufacturers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    DisplayName = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    PowerConsumption = table.Column<float>(type: "REAL", nullable: false),
                    PowerConsumptionExponent = table.Column<float>(type: "REAL", nullable: false),
                    IsOverclockable = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuildableManufacturers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    DisplayName = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Form = table.Column<int>(type: "INTEGER", nullable: false),
                    StackSize = table.Column<int>(type: "INTEGER", nullable: false),
                    IsRadioactive = table.Column<bool>(type: "INTEGER", nullable: false),
                    FluidColorHexa = table.Column<string>(type: "TEXT", nullable: false),
                    GasColorHexa = table.Column<string>(type: "TEXT", nullable: false),
                    SmallIcon = table.Column<string>(type: "TEXT", nullable: false),
                    BigIcon = table.Column<string>(type: "TEXT", nullable: false),
                    IsEvent = table.Column<bool>(type: "INTEGER", nullable: false),
                    ResourceSinkPoints = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    DisplayName = table.Column<string>(type: "TEXT", nullable: false),
                    ManufactoringDuration = table.Column<float>(type: "REAL", nullable: false),
                    ManualManufacturingMultiplier = table.Column<float>(type: "REAL", nullable: false),
                    ProducedInId = table.Column<string>(type: "TEXT", nullable: false),
                    IsAlternate = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recipes_BuildableManufacturers_ProducedInId",
                        column: x => x.ProducedInId,
                        principalTable: "BuildableManufacturers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecipeIngredients",
                columns: table => new
                {
                    RecipeId = table.Column<string>(type: "TEXT", nullable: false),
                    ItemId = table.Column<string>(type: "TEXT", nullable: false),
                    Amount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeIngredients", x => new { x.RecipeId, x.ItemId });
                    table.ForeignKey(
                        name: "FK_RecipeIngredients_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecipeIngredients_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecipeProducts",
                columns: table => new
                {
                    RecipeId = table.Column<string>(type: "TEXT", nullable: false),
                    ItemId = table.Column<string>(type: "TEXT", nullable: false),
                    Amount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeProducts", x => new { x.RecipeId, x.ItemId });
                    table.ForeignKey(
                        name: "FK_RecipeProducts_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecipeProducts_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "BuildableManufacturers",
                columns: new[] { "Id", "Description", "DisplayName", "IsOverclockable", "PowerConsumption", "PowerConsumptionExponent" },
                values: new object[] { "Build_AssemblerMk1_C", "Crafts two parts into another part.\r\n\r\nCan be automated by feeding parts into it with a conveyor belt connected to the input. The produced parts can be automatically extracted by connecting a conveyor belt to the output.", "Assembler", true, 15f, 1.6f });

            migrationBuilder.InsertData(
                table: "BuildableManufacturers",
                columns: new[] { "Id", "Description", "DisplayName", "IsOverclockable", "PowerConsumption", "PowerConsumptionExponent" },
                values: new object[] { "Build_Blender_C", "The Blender is capable of blending fluids and combining them with solid parts in various processes.\r\nHead Lift: 10 meters.\r\n(Allows fluids to be transported 10 meters upwards).\r\n\r\nContains both Conveyor Belt and Pipe inputs and outputs.", "Blender", true, 75f, 1.6f });

            migrationBuilder.InsertData(
                table: "BuildableManufacturers",
                columns: new[] { "Id", "Description", "DisplayName", "IsOverclockable", "PowerConsumption", "PowerConsumptionExponent" },
                values: new object[] { "Build_ConstructorMk1_C", "Crafts one part into another part.\r\n\r\nCan be automated by feeding parts into it with a conveyor belt connected to the input. The produced parts can be automatically extracted by connecting a conveyor belt to the output.", "Constructor", true, 4f, 1.6f });

            migrationBuilder.InsertData(
                table: "BuildableManufacturers",
                columns: new[] { "Id", "Description", "DisplayName", "IsOverclockable", "PowerConsumption", "PowerConsumptionExponent" },
                values: new object[] { "Build_FoundryMk1_C", "Smelts two resources into alloy ingots.\r\n\r\nCan be automated by feeding ore into it with a conveyor belt connected to the inputs. The produced ingots can be automatically extracted by connecting a conveyor belt to the output.", "Foundry", true, 16f, 1.6f });

            migrationBuilder.InsertData(
                table: "BuildableManufacturers",
                columns: new[] { "Id", "Description", "DisplayName", "IsOverclockable", "PowerConsumption", "PowerConsumptionExponent" },
                values: new object[] { "Build_ManufacturerMk1_C", "Crafts three or four parts into another part.\r\n\r\nCan be automated by feeding parts into it with a conveyor belt connected to the input. The produced parts can be automatically extracted by connecting a conveyor belt to the output.", "Manufacturer", true, 55f, 1.6f });

            migrationBuilder.InsertData(
                table: "BuildableManufacturers",
                columns: new[] { "Id", "Description", "DisplayName", "IsOverclockable", "PowerConsumption", "PowerConsumptionExponent" },
                values: new object[] { "Build_OilRefinery_C", "Refines fluid and/or solid parts into other parts.\r\nHead Lift: 10 meters.\r\n(Allows fluids to be transported 10 meters upwards.)\r\n\r\nContains both a Conveyor Belt and Pipe input and output, to allow for the automation of various recipes.", "Refinery", true, 30f, 1.6f });

            migrationBuilder.InsertData(
                table: "BuildableManufacturers",
                columns: new[] { "Id", "Description", "DisplayName", "IsOverclockable", "PowerConsumption", "PowerConsumptionExponent" },
                values: new object[] { "Build_Packager_C", "Used for the packaging and unpacking of fluids.\r\nHead Lift: 10 meters.\r\n(Allows fluids to be transported 10 meters upwards.)\r\n\r\nContains both a Conveyor Belt and Pipe input and output, to allow for the automation of various recipes.", "Packager", true, 10f, 1.6f });

            migrationBuilder.InsertData(
                table: "BuildableManufacturers",
                columns: new[] { "Id", "Description", "DisplayName", "IsOverclockable", "PowerConsumption", "PowerConsumptionExponent" },
                values: new object[] { "Build_SmelterMk1_C", "Smelts ore into ingots.\r\n\r\nCan be automated by feeding ore into it with a conveyor belt connected to the input. The produced ingots can be automatically extracted by connecting a conveyor belt to the output.", "Smelter", true, 4f, 1.6f });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BigIcon", "Description", "DisplayName", "FluidColorHexa", "Form", "GasColorHexa", "IsEvent", "IsRadioactive", "ResourceSinkPoints", "SmallIcon", "StackSize" },
                values: new object[] { "BP_EqDescZipLine_C", "IconDesc_Zipline_256", "Slot: Hand\r\n\r\nProvides faster traversal in factories by allowing Pioneers to zip along Power lines.\r\nActivate the Zipline and aim at a nearby Power Line to connect to it.", "Zipline", "#00000000", 2, "#00000000", false, false, 5284, "IconDesc_Zipline_64", 1 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BigIcon", "Description", "DisplayName", "FluidColorHexa", "Form", "GasColorHexa", "IsEvent", "IsRadioactive", "ResourceSinkPoints", "SmallIcon", "StackSize" },
                values: new object[] { "BP_EquipmentDescriptorBeacon_C", "IconDesc_Beacon_256", "Slot: Hands\r\nConsumable\r\n\r\nUsed to mark areas of interest. Displayed on your compass with the color and name you set for it.", "Beacon", "#00000000", 2, "#00000000", false, false, 320, "IconDesc_Beacon_64", 100 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BigIcon", "Description", "DisplayName", "FluidColorHexa", "Form", "GasColorHexa", "IsEvent", "IsRadioactive", "ResourceSinkPoints", "SmallIcon", "StackSize" },
                values: new object[] { "BP_EquipmentDescriptorCandyCane_C", "IconDesc_CaneEquipment_256", "Slot: Hands\r\n\r\nHeavy delicious self defense weapon for melee range.", "Candy Cane Basher", "#00000000", 2, "#00000000", true, false, 1, "IconDesc_CaneEquipment_64", 1 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BigIcon", "Description", "DisplayName", "FluidColorHexa", "Form", "GasColorHexa", "IsEvent", "IsRadioactive", "ResourceSinkPoints", "SmallIcon", "StackSize" },
                values: new object[] { "BP_EquipmentDescriptorGasmask_C", "GasMask_256", "Slot: Body\r\n\r\nAllows you to breathe normally in poison gas. Consumes Gas Filters from your inventory when you are in poison gas.", "Gas Mask", "#00000000", 2, "#00000000", false, false, 55000, "GasMask_64", 1 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BigIcon", "Description", "DisplayName", "FluidColorHexa", "Form", "GasColorHexa", "IsEvent", "IsRadioactive", "ResourceSinkPoints", "SmallIcon", "StackSize" },
                values: new object[] { "BP_EquipmentDescriptorHazmatSuit_C", "IconDesc_HazmatSuit_256", "Slot: Body\r\n\r\nShields you from the adverse effects of radiation. \r\nConsumes Iodine Infused Filters from your inventory when you are in radioactive areas.", "Hazmat Suit", "#00000000", 2, "#00000000", false, false, 54100, "IconDesc_HazmatSuit_64", 1 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BigIcon", "Description", "DisplayName", "FluidColorHexa", "Form", "GasColorHexa", "IsEvent", "IsRadioactive", "ResourceSinkPoints", "SmallIcon", "StackSize" },
                values: new object[] { "BP_EquipmentDescriptorHoverPack_C", "IconDesc_Hoverpack_256", "Slot: Body\r\nPower consumption: 100 MW\r\n\r\nAllows for vertical movement and hovering in mid-air to improve building efficiency and factory traversal. Wirelessly connects to nearby power connections, such as Power Poles and Buildings, for power consumption.\r\n\r\nSlow-fall: Hold ascend input after losing connection mid-air.\r\nDisable Hoverpack: Double tap descend input while hovering.", "Hover Pack", "#00000000", 2, "#00000000", false, false, 413920, "IconDesc_Hoverpack_64", 1 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BigIcon", "Description", "DisplayName", "FluidColorHexa", "Form", "GasColorHexa", "IsEvent", "IsRadioactive", "ResourceSinkPoints", "SmallIcon", "StackSize" },
                values: new object[] { "BP_EquipmentDescriptorJetPack_C", "Jetpack_256", "Slot: Body\r\n\r\nAllows you to move more freely in the air. Consumes Fuel when used and refills with Fuel from your inventory when you're on the ground.", "Jetpack", "#00000000", 2, "#00000000", false, false, 49580, "Jetpack_64", 1 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BigIcon", "Description", "DisplayName", "FluidColorHexa", "Form", "GasColorHexa", "IsEvent", "IsRadioactive", "ResourceSinkPoints", "SmallIcon", "StackSize" },
                values: new object[] { "BP_EquipmentDescriptorJumpingStilts_C", "IconDesc_SprintingStilts_256", "Slot: Body\r\n\r\nAn exoskeleton for your lower legs that assists movement, allowing you to sprint faster and jump higher.\r\nAlso dampens the impact of landing.", "Blade Runners", "#00000000", 2, "#00000000", false, false, 4988, "IconDesc_SprintingStilts_64", 1 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BigIcon", "Description", "DisplayName", "FluidColorHexa", "Form", "GasColorHexa", "IsEvent", "IsRadioactive", "ResourceSinkPoints", "SmallIcon", "StackSize" },
                values: new object[] { "BP_EquipmentDescriptorNobeliskDetonator_C", "Detonator_256", "Slot: Hands\r\nAmmo: Nobelisk\r\n\r\nUsed to blow up cracked boulders, rocks and invasive vegetation.", "Nobelisk Detonator", "#00000000", 2, "#00000000", false, false, 39520, "Detonator_64", 1 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BigIcon", "Description", "DisplayName", "FluidColorHexa", "Form", "GasColorHexa", "IsEvent", "IsRadioactive", "ResourceSinkPoints", "SmallIcon", "StackSize" },
                values: new object[] { "BP_EquipmentDescriptorObjectScanner_C", "ObjectScanner_256", "Slot: Hands\r\n\r\nScans the area for a set item. Beeps at a rate proportional to proximity and direction.", "Object Scanner", "#00000000", 2, "#00000000", false, false, 3080, "ObjectScanner_64", 1 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BigIcon", "Description", "DisplayName", "FluidColorHexa", "Form", "GasColorHexa", "IsEvent", "IsRadioactive", "ResourceSinkPoints", "SmallIcon", "StackSize" },
                values: new object[] { "BP_EquipmentDescriptorRifle_C", "RifleMk1_256", "Slot: Hands\r\nAmmo: Rifle Cartridges\r\n\r\nRapid-firing weapon for self-defense.", "Rifle", "#00000000", 2, "#00000000", false, false, 99160, "RifleMK1_64", 1 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BigIcon", "Description", "DisplayName", "FluidColorHexa", "Form", "GasColorHexa", "IsEvent", "IsRadioactive", "ResourceSinkPoints", "SmallIcon", "StackSize" },
                values: new object[] { "BP_EquipmentDescriptorShockShank_C", "IconDesc_XenoZapper_256", "Slot: Hands\r\n\r\nStandard issue electroshock self defense weapon for melee range.", "Xeno-Zapper", "#00000000", 2, "#00000000", false, false, 1880, "IconDesc_XenoZapper_64", 1 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BigIcon", "Description", "DisplayName", "FluidColorHexa", "Form", "GasColorHexa", "IsEvent", "IsRadioactive", "ResourceSinkPoints", "SmallIcon", "StackSize" },
                values: new object[] { "BP_EquipmentDescriptorStunSpear_C", "ShockBaton_256", "Slot: Hands\r\n\r\nHeavy electroshock self defense weapon for melee range.", "Xeno-Basher", "#00000000", 2, "#00000000", false, false, 18800, "ShockBaton_64", 1 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BigIcon", "Description", "DisplayName", "FluidColorHexa", "Form", "GasColorHexa", "IsEvent", "IsRadioactive", "ResourceSinkPoints", "SmallIcon", "StackSize" },
                values: new object[] { "BP_ItemDescriptorPortableMiner_C", "PortableMiner_256", "Slot: Hands\r\n\r\nCan be set up on a resource node to automatically extract the resource. Very limited storage space.", "Portable Miner", "#00000000", 2, "#00000000", false, false, 56, "PortableMiner_64", 1 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BigIcon", "Description", "DisplayName", "FluidColorHexa", "Form", "GasColorHexa", "IsEvent", "IsRadioactive", "ResourceSinkPoints", "SmallIcon", "StackSize" },
                values: new object[] { "Desc_AluminaSolution_C", "LiquidAlumina_Pipe_512", "Dissolved Alumina, extracted from Bauxite. Can be further refined into Aluminum Scrap for Aluminum Ingot production.", "Alumina Solution", "#C1C1C1FF", 3, "#00000000", false, false, 20, "LiquidAlumina_Pipe_256", 0 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BigIcon", "Description", "DisplayName", "FluidColorHexa", "Form", "GasColorHexa", "IsEvent", "IsRadioactive", "ResourceSinkPoints", "SmallIcon", "StackSize" },
                values: new object[] { "Desc_AluminumCasing_C", "IconDesc_AluminiumCasing_256", "A versatile container cast from Aluminum Ingots.", "Aluminum Casing", "#00000000", 2, "#00000000", false, false, 393, "IconDesc_AluminiumCasing_64", 200 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BigIcon", "Description", "DisplayName", "FluidColorHexa", "Form", "GasColorHexa", "IsEvent", "IsRadioactive", "ResourceSinkPoints", "SmallIcon", "StackSize" },
                values: new object[] { "Desc_AluminumIngot_C", "IconDesc_AluminiumIngot_256", "Aluminum Ingots are made from Aluminum Scrap, which is refined from Alumina Solution.\r\nUsed to produce specialized aluminum-based parts.", "Aluminum Ingot", "#00000000", 2, "#00000000", false, false, 131, "IconDesc_AluminiumIngot_64", 100 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BigIcon", "Description", "DisplayName", "FluidColorHexa", "Form", "GasColorHexa", "IsEvent", "IsRadioactive", "ResourceSinkPoints", "SmallIcon", "StackSize" },
                values: new object[] { "Desc_AluminumPlate_C", "IconDesc_AluminiumSheet_256", "Thin, lightweight, and highly durable sheets that are mainly used for products that require high heat conduction or a high specific strength.", "Alclad Aluminum Sheet", "#00000000", 2, "#00000000", false, false, 266, "IconDesc_AluminiumSheet_64", 200 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BigIcon", "Description", "DisplayName", "FluidColorHexa", "Form", "GasColorHexa", "IsEvent", "IsRadioactive", "ResourceSinkPoints", "SmallIcon", "StackSize" },
                values: new object[] { "Desc_AluminumPlateReinforced_C", "IconDesc_Heatsink_256", "Used to dissipate heat faster.", "Heat Sink", "#00000000", 2, "#00000000", false, false, 2804, "IconDesc_Heatsink_64", 100 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BigIcon", "Description", "DisplayName", "FluidColorHexa", "Form", "GasColorHexa", "IsEvent", "IsRadioactive", "ResourceSinkPoints", "SmallIcon", "StackSize" },
                values: new object[] { "Desc_AluminumScrap_C", "IconDesc_AluminiumScrap_256", "Aluminum Scrap is pure aluminum refined from Alumina. Can be smelted down to Aluminum Ingots for industrial usage.", "Aluminum Scrap", "#00000000", 2, "#00000000", false, false, 27, "IconDesc_AluminiumScrap_64", 500 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BigIcon", "Description", "DisplayName", "FluidColorHexa", "Form", "GasColorHexa", "IsEvent", "IsRadioactive", "ResourceSinkPoints", "SmallIcon", "StackSize" },
                values: new object[] { "Desc_Battery_C", "IconDesc_Battery_256", "Primarily used as fuel for Drones and Vehicles.", "Battery", "#00000000", 2, "#00000000", false, false, 465, "IconDesc_Battery_64", 200 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BigIcon", "Description", "DisplayName", "FluidColorHexa", "Form", "GasColorHexa", "IsEvent", "IsRadioactive", "ResourceSinkPoints", "SmallIcon", "StackSize" },
                values: new object[] { "Desc_Berry_C", "IconDesc_Berry_256", "Slot: Hands\r\nConsumable\r\n\r\nCan be eaten to restore one health segment.", "Paleberry", "#00000000", 2, "#00000000", false, false, 0, "IconDesc_Berry_64", 50 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BigIcon", "Description", "DisplayName", "FluidColorHexa", "Form", "GasColorHexa", "IsEvent", "IsRadioactive", "ResourceSinkPoints", "SmallIcon", "StackSize" },
                values: new object[] { "Desc_Biofuel_C", "IconDesc_SolidBiofuel_256", "The most energy-efficient form of solid biomass. Can be used as fuel for the Chainsaw.", "Solid Biofuel", "#00000000", 2, "#00000000", false, false, 48, "IconDesc_SolidBiofuel_64", 200 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BigIcon", "Description", "DisplayName", "FluidColorHexa", "Form", "GasColorHexa", "IsEvent", "IsRadioactive", "ResourceSinkPoints", "SmallIcon", "StackSize" },
                values: new object[] { "Desc_Cable_C", "IconDesc_Cables_256", "Used for crafting.\r\nPrimarily used to build power lines.", "Cable", "#00000000", 2, "#00000000", false, false, 24, "IconDesc_Cables_64", 200 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BigIcon", "Description", "DisplayName", "FluidColorHexa", "Form", "GasColorHexa", "IsEvent", "IsRadioactive", "ResourceSinkPoints", "SmallIcon", "StackSize" },
                values: new object[] { "Desc_CandyCane_C", "IconDesc_CanePart_256", "A delicious Candy Cane to be enjoyed during the FICSMAS Holidays. \r\n*Disclaimer: Can't be consumed...", "Candy Cane", "#00000000", 2, "#00000000", true, false, 1, "IconDesc_CanePart_64", 500 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BigIcon", "Description", "DisplayName", "FluidColorHexa", "Form", "GasColorHexa", "IsEvent", "IsRadioactive", "ResourceSinkPoints", "SmallIcon", "StackSize" },
                values: new object[] { "Desc_CartridgeStandard_C", "Rifle_Magazine_256", "Ammo for the Rifle.", "Rifle Cartridge", "#00000000", 2, "#00000000", false, false, 664, "Rifle_Magazine_64", 100 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BigIcon", "Description", "DisplayName", "FluidColorHexa", "Form", "GasColorHexa", "IsEvent", "IsRadioactive", "ResourceSinkPoints", "SmallIcon", "StackSize" },
                values: new object[] { "Desc_Cement_C", "IconDesc_Concrete_256", "Used for building.\r\nGood for stable foundations.", "Concrete", "#00000000", 2, "#00000000", false, false, 12, "IconDesc_Concrete_64", 500 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BigIcon", "Description", "DisplayName", "FluidColorHexa", "Form", "GasColorHexa", "IsEvent", "IsRadioactive", "ResourceSinkPoints", "SmallIcon", "StackSize" },
                values: new object[] { "Desc_CircuitBoard_C", "IconDesc_CircuitBoard_256", "Circuit Boards are advanced electronics that are used in a plethora of different ways.", "Circuit Board", "#00000000", 2, "#00000000", false, false, 696, "IconDesc_CircuitBoard_64", 200 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BigIcon", "Description", "DisplayName", "FluidColorHexa", "Form", "GasColorHexa", "IsEvent", "IsRadioactive", "ResourceSinkPoints", "SmallIcon", "StackSize" },
                values: new object[] { "Desc_CircuitBoardHighSpeed_C", "IconDesc_AILimiter_256", "AI Limiters are super advanced electronics that are used to control AIs and keep them from evolving in malicious ways.", "AI Limiter", "#00000000", 2, "#00000000", false, false, 920, "IconDesc_AILimiter_64", 100 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BigIcon", "Description", "DisplayName", "FluidColorHexa", "Form", "GasColorHexa", "IsEvent", "IsRadioactive", "ResourceSinkPoints", "SmallIcon", "StackSize" },
                values: new object[] { "Desc_Coal_C", "IconDesc_CoalOre_256", "Mainly used as fuel for vehicles & coal generators and for steel production.", "Coal", "#00000000", 2, "#00000000", false, false, 3, "IconDesc_CoalOre_64", 100 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BigIcon", "Description", "DisplayName", "FluidColorHexa", "Form", "GasColorHexa", "IsEvent", "IsRadioactive", "ResourceSinkPoints", "SmallIcon", "StackSize" },
                values: new object[] { "Desc_ColorCartridge_C", "IconDesc_ColorCartridge_256", "Used for applying Patterns to structures with the Customizer.\r\n\r\n(Patterns can be purchased in the AWESOME Shop.)", "Color Cartridge", "#00000000", 2, "#00000000", false, false, 10, "IconDesc_ColorCartridge_64", 200 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BigIcon", "Description", "DisplayName", "FluidColorHexa", "Form", "GasColorHexa", "IsEvent", "IsRadioactive", "ResourceSinkPoints", "SmallIcon", "StackSize" },
                values: new object[] { "Desc_CompactedCoal_C", "IconDesc_CompactedCoal_256", "A much more efficient alternative for Coal. Used as fuel for vehicles & coal generators.", "Compacted Coal", "#00000000", 2, "#00000000", false, false, 28, "IconDesc_CompactedCoal_64", 100 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BigIcon", "Description", "DisplayName", "FluidColorHexa", "Form", "GasColorHexa", "IsEvent", "IsRadioactive", "ResourceSinkPoints", "SmallIcon", "StackSize" },
                values: new object[] { "Desc_Computer_C", "IconDesc_Computer_256", "A Computer is a complex logic machine that is used to control advanced behaviour in machines.", "Computer", "#00000000", 2, "#00000000", false, false, 17260, "IconDesc_Computer_64", 50 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BigIcon", "Description", "DisplayName", "FluidColorHexa", "Form", "GasColorHexa", "IsEvent", "IsRadioactive", "ResourceSinkPoints", "SmallIcon", "StackSize" },
                values: new object[] { "Desc_ComputerSuper_C", "IconDesc_SuperComputer_256", "The supercomputer is the next-gen version of the computer.", "Supercomputer", "#00000000", 2, "#00000000", false, false, 99576, "IconDesc_SuperComputer_64", 50 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BigIcon", "Description", "DisplayName", "FluidColorHexa", "Form", "GasColorHexa", "IsEvent", "IsRadioactive", "ResourceSinkPoints", "SmallIcon", "StackSize" },
                values: new object[] { "Desc_CoolingSystem_C", "IconDesc_CoolingSystem_256", "Used to keep temperatures of advanced parts and buildings from exceeding to inefficient levels.", "Cooling System", "#00000000", 2, "#00000000", false, false, 12006, "IconDesc_CoolingSystem_64", 100 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BigIcon", "Description", "DisplayName", "FluidColorHexa", "Form", "GasColorHexa", "IsEvent", "IsRadioactive", "ResourceSinkPoints", "SmallIcon", "StackSize" },
                values: new object[] { "Desc_CopperDust_C", "IconDesc_CopperDust_256", "Ground down Copper Ingots.\r\nThe high natural density of Copper, combined with the granularity of the powder, make this part fit for producing Nuclear Pasta in the Particle Accelerator.", "Copper Powder", "#00000000", 2, "#00000000", false, false, 72, "IconDesc_CopperDust_64", 500 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BigIcon", "Description", "DisplayName", "FluidColorHexa", "Form", "GasColorHexa", "IsEvent", "IsRadioactive", "ResourceSinkPoints", "SmallIcon", "StackSize" },
                values: new object[] { "Desc_CopperIngot_C", "IconDesc_CopperIngot_256", "Used for crafting.\r\nCrafted into the most basic parts.", "Copper Ingot", "#00000000", 2, "#00000000", false, false, 6, "IconDesc_CopperIngot_64", 100 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BigIcon", "Description", "DisplayName", "FluidColorHexa", "Form", "GasColorHexa", "IsEvent", "IsRadioactive", "ResourceSinkPoints", "SmallIcon", "StackSize" },
                values: new object[] { "Desc_CopperSheet_C", "IconDesc_CopperSheet_256", "Used for crafting.\r\nPrimarily used for pipelines due to its high corrosion resistance.", "Copper Sheet", "#00000000", 2, "#00000000", false, false, 24, "IconDesc_CopperSheet_64", 200 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BigIcon", "Description", "DisplayName", "FluidColorHexa", "Form", "GasColorHexa", "IsEvent", "IsRadioactive", "ResourceSinkPoints", "SmallIcon", "StackSize" },
                values: new object[] { "Desc_Crystal_C", "PowerSlugGreen_256", "A strange slug radiating a weak strange power.", "Blue Power Slug", "#00000000", 2, "#00000000", false, false, 0, "PowerSlugGreen_64", 50 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BigIcon", "Description", "DisplayName", "FluidColorHexa", "Form", "GasColorHexa", "IsEvent", "IsRadioactive", "ResourceSinkPoints", "SmallIcon", "StackSize" },
                values: new object[] { "Desc_Crystal_mk2_C", "PowerSlugYellow_256", "A strange slug radiating a strange power.", "Yellow Power Slug", "#00000000", 2, "#00000000", false, false, 0, "PowerSlugYellow_64", 50 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BigIcon", "Description", "DisplayName", "FluidColorHexa", "Form", "GasColorHexa", "IsEvent", "IsRadioactive", "ResourceSinkPoints", "SmallIcon", "StackSize" },
                values: new object[] { "Desc_Crystal_mk3_C", "PowerSlugPurple_256", "A strange slug radiating a powerful strange power.", "Purple Power Slug", "#00000000", 2, "#00000000", false, false, 0, "PowerSlugPurple_64", 50 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BigIcon", "Description", "DisplayName", "FluidColorHexa", "Form", "GasColorHexa", "IsEvent", "IsRadioactive", "ResourceSinkPoints", "SmallIcon", "StackSize" },
                values: new object[] { "Desc_CrystalOscillator_C", "IconDesc_CrystalOscillator_256", "A crystal oscillator is an electronic oscillator circuit that uses the mechanical resonance of a vibrating crystal to create an electrical signal with a precise frequency.", "Crystal Oscillator", "#00000000", 2, "#00000000", false, false, 3072, "IconDesc_CrystalOscillator_64", 100 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BigIcon", "Description", "DisplayName", "FluidColorHexa", "Form", "GasColorHexa", "IsEvent", "IsRadioactive", "ResourceSinkPoints", "SmallIcon", "StackSize" },
                values: new object[] { "Desc_CrystalShard_C", "PowerShard_256", "Mucus from the power slugs compressed into a solid crystal-like shard. \r\nIt radiates a strange power.", "Power Shard", "#00000000", 2, "#00000000", false, false, 0, "PowerShard_64", 100 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BigIcon", "Description", "DisplayName", "FluidColorHexa", "Form", "GasColorHexa", "IsEvent", "IsRadioactive", "ResourceSinkPoints", "SmallIcon", "StackSize" },
                values: new object[] { "Desc_ElectromagneticControlRod_C", "IconDesc_ElectromagneticControlRod_256", "Control Rods regulate power output via electromagnetism.", "Electromagnetic Control Rod", "#00000000", 2, "#00000000", false, false, 2560, "IconDesc_ElectromagneticControlRod_64", 100 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BigIcon", "Description", "DisplayName", "FluidColorHexa", "Form", "GasColorHexa", "IsEvent", "IsRadioactive", "ResourceSinkPoints", "SmallIcon", "StackSize" },
                values: new object[] { "Desc_Fabric_C", "IconDesc_Fabric_256", "Used for equipment crafting.\r\nFlexible but durable fabric.", "Fabric", "#00000000", 2, "#00000000", false, false, 140, "IconDesc_Fabric_64", 100 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BigIcon", "Description", "DisplayName", "FluidColorHexa", "Form", "GasColorHexa", "IsEvent", "IsRadioactive", "ResourceSinkPoints", "SmallIcon", "StackSize" },
                values: new object[] { "Desc_Filter_C", "IconDesc_GasMaskFilter_256", "Used in gas masks to filter out pollutants in the air.", "Gas Filter", "#00000000", 2, "#00000000", false, false, 830, "IconDesc_GasMaskFilter_64", 50 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BigIcon", "Description", "DisplayName", "FluidColorHexa", "Form", "GasColorHexa", "IsEvent", "IsRadioactive", "ResourceSinkPoints", "SmallIcon", "StackSize" },
                values: new object[] { "Desc_Fireworks_Projectile_01_C", "IconDesc_Rocket01_256", "Merry FICSMAS and a Happy New Year!\r\n\r\nAlternative Nobelisk Ammo. Use G to swap!", "Sweet Fireworks", "#00000000", 2, "#00000000", true, false, 0, "IconDesc_Rocket01_64", 500 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BigIcon", "Description", "DisplayName", "FluidColorHexa", "Form", "GasColorHexa", "IsEvent", "IsRadioactive", "ResourceSinkPoints", "SmallIcon", "StackSize" },
                values: new object[] { "Desc_Fireworks_Projectile_02_C", "IconDesc_Rocket02_256", "Fireworks are produced from random ingredients. Primarily used for having a good time.\r\n\r\nAlternative Nobelisk Ammo. Use G to swap!", "Fancy Fireworks", "#00000000", 2, "#00000000", true, false, 0, "IconDesc_Rocket02_64", 500 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BigIcon", "Description", "DisplayName", "FluidColorHexa", "Form", "GasColorHexa", "IsEvent", "IsRadioactive", "ResourceSinkPoints", "SmallIcon", "StackSize" },
                values: new object[] { "Desc_Fireworks_Projectile_03_C", "IconDesc_Rocket03_256", "Goes Pfffeeeeew... BOOM! *Sparkle*\r\n\r\nAlternative Nobelisk Ammo. Use G to swap!", "Sparkly Fireworks", "#00000000", 2, "#00000000", true, false, 0, "IconDesc_Rocket03_64", 500 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BigIcon", "Description", "DisplayName", "FluidColorHexa", "Form", "GasColorHexa", "IsEvent", "IsRadioactive", "ResourceSinkPoints", "SmallIcon", "StackSize" },
                values: new object[] { "Desc_FlowerPetals_C", "FlowerPetals_Final_256", "Used for crafting.\r\nColorful native flower petals.", "Flower Petals", "#00000000", 2, "#00000000", false, false, 10, "FlowerPetals_Final_64", 500 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BigIcon", "Description", "DisplayName", "FluidColorHexa", "Form", "GasColorHexa", "IsEvent", "IsRadioactive", "ResourceSinkPoints", "SmallIcon", "StackSize" },
                values: new object[] { "Desc_FluidCanister_C", "IconDesc_EmptyCannister_256", "Used to package fluids for transportation.", "Empty Canister", "#00000000", 2, "#00000000", false, false, 60, "IconDesc_EmptyCannister_64", 100 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BigIcon", "Description", "DisplayName", "FluidColorHexa", "Form", "GasColorHexa", "IsEvent", "IsRadioactive", "ResourceSinkPoints", "SmallIcon", "StackSize" },
                values: new object[] { "Desc_Fuel_C", "IconDesc_Fuel_256", "Fuel, packaged for alternative transport. Can be used as fuel for Vehicles or the Jetpack.", "Packaged Fuel", "#EB7D15FF", 2, "#00000000", false, false, 270, "IconDesc_Fuel_64", 100 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BigIcon", "Description", "DisplayName", "FluidColorHexa", "Form", "GasColorHexa", "IsEvent", "IsRadioactive", "ResourceSinkPoints", "SmallIcon", "StackSize" },
                values: new object[] { "Desc_GasTank_C", "IconDesc_PressureTank_256", "Used to package gases and volatile liquids for transportation.", "Empty Fluid Tank", "#00000000", 2, "#00000000", false, false, 225, "IconDesc_PressureTank_64", 100 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BigIcon", "Description", "DisplayName", "FluidColorHexa", "Form", "GasColorHexa", "IsEvent", "IsRadioactive", "ResourceSinkPoints", "SmallIcon", "StackSize" },
                values: new object[] { "Desc_GenericBiomass_C", "IconDesc_Biomass_Final_256", "Primarily used as fuel.\r\nBiomass burners and vehicles can use it for power.\r\nBiomass is much more energy-efficient than raw biological matter.", "Biomass", "#00000000", 2, "#00000000", false, false, 12, "IconDesc_Biomass_Final_64", 200 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BigIcon", "Description", "DisplayName", "FluidColorHexa", "Form", "GasColorHexa", "IsEvent", "IsRadioactive", "ResourceSinkPoints", "SmallIcon", "StackSize" },
                values: new object[] { "Desc_Gift_C", "IconDesc_Gift_256", "Special FICSMAS buildings and parts can be obtained and produced from this FICSIT Holiday present.\r\n\r\n*Watch the sky for deliveries from orbit!", "FICSMAS Gift", "#00000000", 2, "#00000000", true, false, 1, "IconDesc_Gift_64", 500 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BigIcon", "Description", "DisplayName", "FluidColorHexa", "Form", "GasColorHexa", "IsEvent", "IsRadioactive", "ResourceSinkPoints", "SmallIcon", "StackSize" },
                values: new object[] { "Desc_GoldIngot_C", "IconDesc_CateriumIngot_256", "Caterium Ingots are smelted from Caterium Ore. Caterium Ingots are mostly used for advanced electronics.", "Caterium Ingot", "#00000000", 2, "#00000000", false, false, 42, "IconDesc_CateriumIngot_64", 100 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BigIcon", "Description", "DisplayName", "FluidColorHexa", "Form", "GasColorHexa", "IsEvent", "IsRadioactive", "ResourceSinkPoints", "SmallIcon", "StackSize" },
                values: new object[] { "Desc_GolfCart_C", "IconDesc_GolfCart_256", "The one and only FICSIT Factory Cart™\r\nNow with special - FICSIT Foundation only - Grip Wheels, for an even smoother and faster factory floor experience!", "Factory Cart™", "#00000000", 2, "#00000000", false, false, 1552, "IconDesc_GolfCart_64", 1 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BigIcon", "Description", "DisplayName", "FluidColorHexa", "Form", "GasColorHexa", "IsEvent", "IsRadioactive", "ResourceSinkPoints", "SmallIcon", "StackSize" },
                values: new object[] { "Desc_GolfCartGold_C", "IconDesc_GolfCartGold_256", "The one and only Golden FICSIT Factory Cart™\r\n\r\nYou have now officially ascended. \r\nGo forth now, Master of Spaghetti, God of the Factory, Sinker of Cups, Employee of the Planet... travel in STYLE!", "Golden Factory Cart™", "#00000000", 2, "#00000000", false, false, 0, "IconDesc_GolfCartGold_64", 1 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BigIcon", "Description", "DisplayName", "FluidColorHexa", "Form", "GasColorHexa", "IsEvent", "IsRadioactive", "ResourceSinkPoints", "SmallIcon", "StackSize" },
                values: new object[] { "Desc_Gunpowder_C", "IconDesc_Gunpowder_256", "An explosive powder that is commonly used in explosives and cartridges.", "Black Powder", "#00000000", 2, "#00000000", false, false, 50, "IconDesc_Gunpowder_64", 100 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BigIcon", "Description", "DisplayName", "FluidColorHexa", "Form", "GasColorHexa", "IsEvent", "IsRadioactive", "ResourceSinkPoints", "SmallIcon", "StackSize" },
                values: new object[] { "Desc_HazmatFilter_C", "IconDesc_HazmatFilter_256", "Used in hazmat suits to filter out radioactive particles in the air.", "Iodine Infused Filter", "#00000000", 2, "#00000000", false, false, 2718, "IconDesc_HazmatFilter_64", 50 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BigIcon", "Description", "DisplayName", "FluidColorHexa", "Form", "GasColorHexa", "IsEvent", "IsRadioactive", "ResourceSinkPoints", "SmallIcon", "StackSize" },
                values: new object[] { "Desc_HeavyOilResidue_C", "IconDesc_LiquidHeavyOilResidue_Pipe_512", "A by-product of Plastic and Rubber production. Can be further refined into Fuel and Petroleum Coke.", "Heavy Oil Residue", "#6D2D78FF", 3, "#00000000", false, false, 30, "IconDesc_LiquidHeavyOilResidue_Pipe_256", 0 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BigIcon", "Description", "DisplayName", "FluidColorHexa", "Form", "GasColorHexa", "IsEvent", "IsRadioactive", "ResourceSinkPoints", "SmallIcon", "StackSize" },
                values: new object[] { "Desc_HighSpeedConnector_C", "IconDesc_HighSpeedConnector_256", "The high-speed connector connects several cables and wires in a very efficient way. Uses a standard pattern so its applications are many and varied.", "High-Speed Connector", "#00000000", 2, "#00000000", false, false, 3776, "IconDesc_HighSpeedConnector_64", 100 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BigIcon", "Description", "DisplayName", "FluidColorHexa", "Form", "GasColorHexa", "IsEvent", "IsRadioactive", "ResourceSinkPoints", "SmallIcon", "StackSize" },
                values: new object[] { "Desc_HighSpeedWire_C", "IconDesc_Quickwire_256", "Caterium's high conductivity and resistance to corrosion makes it ideal for small, advanced electronics.", "Quickwire", "#00000000", 2, "#00000000", false, false, 17, "IconDesc_Quickwire_64", 500 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BigIcon", "Description", "DisplayName", "FluidColorHexa", "Form", "GasColorHexa", "IsEvent", "IsRadioactive", "ResourceSinkPoints", "SmallIcon", "StackSize" },
                values: new object[] { "Desc_HogParts_C", "IconDesc_HogPart_256", "Thick and sturdy natural armor plates from alien creatures.", "Alien Carapace", "#00000000", 2, "#00000000", false, false, 0, "IconDesc_HogPart_64", 50 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BigIcon", "Description", "DisplayName", "FluidColorHexa", "Form", "GasColorHexa", "IsEvent", "IsRadioactive", "ResourceSinkPoints", "SmallIcon", "StackSize" },
                values: new object[] { "Desc_HUBParts_C", "IconDesc_HubParts_256", "The parts required to build the basic structure of the HUB.", "HUB Parts", "#00000000", 2, "#00000000", false, false, 0, "IconDesc_HubParts_64", 1 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BigIcon", "Description", "DisplayName", "FluidColorHexa", "Form", "GasColorHexa", "IsEvent", "IsRadioactive", "ResourceSinkPoints", "SmallIcon", "StackSize" },
                values: new object[] { "Desc_Chainsaw_C", "IconDesc_Chainsaw_256", "Slot: Hands\r\nFuel: Biofuel\r\n\r\nUsed to clear an area of flora that is too difficult to remove by hand.", "Chainsaw", "#00000000", 2, "#00000000", false, false, 2760, "IconDesc_Chainsaw_64", 1 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BigIcon", "Description", "DisplayName", "FluidColorHexa", "Form", "GasColorHexa", "IsEvent", "IsRadioactive", "ResourceSinkPoints", "SmallIcon", "StackSize" },
                values: new object[] { "Desc_IronIngot_C", "IconDesc_IronIngot_256", "Used for crafting.\r\nCrafted into the most basic parts.", "Iron Ingot", "#00000000", 2, "#00000000", false, false, 2, "IconDesc_IronIngot_64", 100 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BigIcon", "Description", "DisplayName", "FluidColorHexa", "Form", "GasColorHexa", "IsEvent", "IsRadioactive", "ResourceSinkPoints", "SmallIcon", "StackSize" },
                values: new object[] { "Desc_IronPlate_C", "IconDesc_IronPlates_256", "Used for crafting.\r\nOne of the most basic parts.", "Iron Plate", "#00000000", 2, "#00000000", false, false, 6, "IconDesc_IronPlates_64", 200 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BigIcon", "Description", "DisplayName", "FluidColorHexa", "Form", "GasColorHexa", "IsEvent", "IsRadioactive", "ResourceSinkPoints", "SmallIcon", "StackSize" },
                values: new object[] { "Desc_IronPlateReinforced_C", "IconDesc_ReinforcedIronPlates_256", "Used for crafting.\r\nA sturdier and more durable Iron Plate.", "Reinforced Iron Plate", "#00000000", 2, "#00000000", false, false, 120, "IconDesc_ReinforcedIronPlates_64", 100 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BigIcon", "Description", "DisplayName", "FluidColorHexa", "Form", "GasColorHexa", "IsEvent", "IsRadioactive", "ResourceSinkPoints", "SmallIcon", "StackSize" },
                values: new object[] { "Desc_IronRod_C", "IconDesc_IronRods_256", "Used for crafting.\r\nOne of the most basic parts.", "Iron Rod", "#00000000", 2, "#00000000", false, false, 4, "IconDesc_IronRods_64", 200 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BigIcon", "Description", "DisplayName", "FluidColorHexa", "Form", "GasColorHexa", "IsEvent", "IsRadioactive", "ResourceSinkPoints", "SmallIcon", "StackSize" },
                values: new object[] { "Desc_IronScrew_C", "IconDesc_IronScrews_256", "Used for crafting.\r\nOne of the most basic parts.", "Screw", "#00000000", 2, "#00000000", false, false, 2, "IconDesc_IronScrews_64", 500 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BigIcon", "Description", "DisplayName", "FluidColorHexa", "Form", "GasColorHexa", "IsEvent", "IsRadioactive", "ResourceSinkPoints", "SmallIcon", "StackSize" },
                values: new object[] { "Desc_Leaves_C", "IconDesc_Leaves_256", "Primarily used as fuel.\r\nBiomass Burners and vehicles can use it for power.", "Leaves", "#00000000", 2, "#00000000", false, false, 3, "IconDesc_Leaves_64", 500 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BigIcon", "Description", "DisplayName", "FluidColorHexa", "Form", "GasColorHexa", "IsEvent", "IsRadioactive", "ResourceSinkPoints", "SmallIcon", "StackSize" },
                values: new object[] { "Desc_LiquidBiofuel_C", "IconDesc_LiquidBiofuel_Pipe_512", "Liquid Biofuel can be used to generate power or packaged to be used as fuel for Vehicles.", "Liquid Biofuel", "#3B532CFF", 3, "#00000000", false, false, 261, "IconDesc_LiquidBiofuel_Pipe_256", 0 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BigIcon", "Description", "DisplayName", "FluidColorHexa", "Form", "GasColorHexa", "IsEvent", "IsRadioactive", "ResourceSinkPoints", "SmallIcon", "StackSize" },
                values: new object[] { "Desc_LiquidFuel_C", "IconDesc_LiquidFuel_Pipe_512", "Fuel can be used to generate power or packaged to be used as fuel for Vehicles or the Jetpack.", "Fuel", "#EB7D15FF", 3, "#00000000", false, false, 75, "IconDesc_LiquidFuel_Pipe_256", 0 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BigIcon", "Description", "DisplayName", "FluidColorHexa", "Form", "GasColorHexa", "IsEvent", "IsRadioactive", "ResourceSinkPoints", "SmallIcon", "StackSize" },
                values: new object[] { "Desc_LiquidOil_C", "LiquidOil_Pipe_512", "Crude Oil is refined into all kinds of Oil-based resources, like Fuel and Plastic.", "Crude Oil", "#190019FF", 3, "#00000000", false, false, 30, "LiquidOil_Pipe_256", 0 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BigIcon", "Description", "DisplayName", "FluidColorHexa", "Form", "GasColorHexa", "IsEvent", "IsRadioactive", "ResourceSinkPoints", "SmallIcon", "StackSize" },
                values: new object[] { "Desc_LiquidTurboFuel_C", "IconDesc_LiquidTurboFuel_Pipe_512", "A more efficient alternative to Fuel. Can be used to generate power or packaged to be used as fuel for Vehicles.", "Turbofuel", "#D4292EFF", 3, "#00000000", false, false, 225, "IconDesc_LiquidTurboFuel_Pipe_256", 0 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BigIcon", "Description", "DisplayName", "FluidColorHexa", "Form", "GasColorHexa", "IsEvent", "IsRadioactive", "ResourceSinkPoints", "SmallIcon", "StackSize" },
                values: new object[] { "Desc_Medkit_C", "Inhaler_256", "Slot: Hands\r\nConsumable\r\n\r\nCan be inhaled to fully restore health.", "Medicinal Inhaler", "#00000000", 2, "#00000000", false, false, 67, "Inhaler_64", 50 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BigIcon", "Description", "DisplayName", "FluidColorHexa", "Form", "GasColorHexa", "IsEvent", "IsRadioactive", "ResourceSinkPoints", "SmallIcon", "StackSize" },
                values: new object[] { "Desc_ModularFrame_C", "IconDesc_ModularFrame_256", "Used for crafting.\r\nMulti-purpose building block.", "Modular Frame", "#00000000", 2, "#00000000", false, false, 408, "IconDesc_ModularFrame_64", 50 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BigIcon", "Description", "DisplayName", "FluidColorHexa", "Form", "GasColorHexa", "IsEvent", "IsRadioactive", "ResourceSinkPoints", "SmallIcon", "StackSize" },
                values: new object[] { "Desc_ModularFrameFused_C", "IconDesc_FusedModularFrame_256", "A corrosion resistant, nitride hardened, highly robust, yet lightweight modular frame.", "Fused Modular Frame", "#00000000", 2, "#00000000", false, false, 62840, "IconDesc_FusedModularFrame_64", 50 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BigIcon", "Description", "DisplayName", "FluidColorHexa", "Form", "GasColorHexa", "IsEvent", "IsRadioactive", "ResourceSinkPoints", "SmallIcon", "StackSize" },
                values: new object[] { "Desc_ModularFrameHeavy_C", "IconDesc_ModularFrameHeavy_256", "A more robust multi-purpose frame.", "Heavy Modular Frame", "#00000000", 2, "#00000000", false, false, 11520, "IconDesc_ModularFrameHeavy_64", 50 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BigIcon", "Description", "DisplayName", "FluidColorHexa", "Form", "GasColorHexa", "IsEvent", "IsRadioactive", "ResourceSinkPoints", "SmallIcon", "StackSize" },
                values: new object[] { "Desc_ModularFrameLightweight_C", "IconDesc_RadioControlUnit_256", "Enhances and directs radio signals.", "Radio Control Unit", "#00000000", 2, "#00000000", false, false, 32908, "IconDesc_RadioControlUnit_64", 50 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BigIcon", "Description", "DisplayName", "FluidColorHexa", "Form", "GasColorHexa", "IsEvent", "IsRadioactive", "ResourceSinkPoints", "SmallIcon", "StackSize" },
                values: new object[] { "Desc_Motor_C", "IconDesc_Engine_256", "The Motor creates a mechanical force that is used to move things from machines to vehicles.", "Motor", "#00000000", 2, "#00000000", false, false, 1520, "IconDesc_Engine_64", 50 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BigIcon", "Description", "DisplayName", "FluidColorHexa", "Form", "GasColorHexa", "IsEvent", "IsRadioactive", "ResourceSinkPoints", "SmallIcon", "StackSize" },
                values: new object[] { "Desc_MotorLightweight_C", "IconDesc_TurboMotor_256", "The Turbo Motor is a more complex, and more powerful, version of the regular Motor.", "Turbo Motor", "#00000000", 2, "#00000000", false, false, 242720, "IconDesc_TurboMotor_64", 50 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BigIcon", "Description", "DisplayName", "FluidColorHexa", "Form", "GasColorHexa", "IsEvent", "IsRadioactive", "ResourceSinkPoints", "SmallIcon", "StackSize" },
                values: new object[] { "Desc_Mycelia_C", "IconDesc_Mycelia_256", "Used for crafting.\r\nBiomass Burners and vehicles can use it for power.", "Mycelia", "#00000000", 2, "#00000000", false, false, 10, "IconDesc_Mycelia_64", 200 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BigIcon", "Description", "DisplayName", "FluidColorHexa", "Form", "GasColorHexa", "IsEvent", "IsRadioactive", "ResourceSinkPoints", "SmallIcon", "StackSize" },
                values: new object[] { "Desc_NitricAcid_C", "IconDesc_NitricAcid_256", "Produced by reaction of Nitrogen Gas with Water. Its high corrosiveness and oxidizing properties make it an excellent choice for refinement and fuel production processes.", "Nitric Acid", "#D9D9A2FF", 3, "#00000000", false, false, 94, "IconDesc_NitricAcid_64", 0 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BigIcon", "Description", "DisplayName", "FluidColorHexa", "Form", "GasColorHexa", "IsEvent", "IsRadioactive", "ResourceSinkPoints", "SmallIcon", "StackSize" },
                values: new object[] { "Desc_NitrogenGas_C", "LiquidAlumina_Pipe_512", "Nitrogen can be used in a variety of ways, such as metallurgy, cooling, and Nitric Acid production. On Massage-2(AB)b, it can be extracted from underground gas wells.", "Nitrogen Gas", "#595959FF", 0, "#FFFFFFFF", false, false, 10, "LiquidAlumina_Pipe_256", 0 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BigIcon", "Description", "DisplayName", "FluidColorHexa", "Form", "GasColorHexa", "IsEvent", "IsRadioactive", "ResourceSinkPoints", "SmallIcon", "StackSize" },
                values: new object[] { "Desc_NobeliskExplosive_C", "IconDesc_Explosive_256", "Can be used with the Nobelisk Detonator to blow up cracked boulders, vegetation or other vulnerable targets.", "Nobelisk", "#00000000", 2, "#00000000", false, false, 980, "IconDesc_Explosive_64", 50 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BigIcon", "Description", "DisplayName", "FluidColorHexa", "Form", "GasColorHexa", "IsEvent", "IsRadioactive", "ResourceSinkPoints", "SmallIcon", "StackSize" },
                values: new object[] { "Desc_NonFissibleUranium_C", "IconDesc_NonFissileUranium_256", "The isotope Uranium-238 is non-fissile, meaning it cannot be used for nuclear fission. It can, however, be conversed into fissile Plutonium in the Particle Accelerator.\r\n\r\nCaution: Mildly Radioactive.", "Non-fissile Uranium", "#00000000", 2, "#00000000", false, true, 0, "IconDesc_NonFissileUranium_64", 500 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BigIcon", "Description", "DisplayName", "FluidColorHexa", "Form", "GasColorHexa", "IsEvent", "IsRadioactive", "ResourceSinkPoints", "SmallIcon", "StackSize" },
                values: new object[] { "Desc_NuclearFuelRod_C", "IconDesc_NuclearFuelRod_256", "Used as fuel for the Nuclear Power Plant.\r\n\r\nCaution: Produces radioactive Uranium Waste when consumed.\r\nCaution: Moderately Radioactive.", "Uranium Fuel Rod", "#00000000", 2, "#00000000", false, true, 44092, "IconDesc_NuclearFuelRod_64", 50 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BigIcon", "Description", "DisplayName", "FluidColorHexa", "Form", "GasColorHexa", "IsEvent", "IsRadioactive", "ResourceSinkPoints", "SmallIcon", "StackSize" },
                values: new object[] { "Desc_NuclearWaste_C", "IconDesc_NuclearWaste_256", "The by-product of consuming Uranium Fuel Rods in the Nuclear Power Plant.\r\nNon-fissible Uranium can be extracted. Handle with caution.\r\n\r\nCaution: HIGHLY Radioactive.", "Uranium Waste", "#00000000", 2, "#00000000", false, true, 0, "IconDesc_NuclearWaste_64", 500 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BigIcon", "Description", "DisplayName", "FluidColorHexa", "Form", "GasColorHexa", "IsEvent", "IsRadioactive", "ResourceSinkPoints", "SmallIcon", "StackSize" },
                values: new object[] { "Desc_Nut_C", "Nut_256_New", "Slot: Hands\r\nConsumable\r\n\r\nCan be eaten to restore half a health segment.", "Beryl Nut", "#00000000", 2, "#00000000", false, false, 0, "Nut_64_new", 100 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BigIcon", "Description", "DisplayName", "FluidColorHexa", "Form", "GasColorHexa", "IsEvent", "IsRadioactive", "ResourceSinkPoints", "SmallIcon", "StackSize" },
                values: new object[] { "Desc_OreBauxite_C", "IconDesc_Bauxite_256", "Bauxite is used to produce Alumina, which can be further refined into the Aluminum Scrap required to produce Aluminum Ingots.", "Bauxite", "#00000000", 2, "#00000000", false, false, 8, "IconDesc_Bauxite_64", 100 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BigIcon", "Description", "DisplayName", "FluidColorHexa", "Form", "GasColorHexa", "IsEvent", "IsRadioactive", "ResourceSinkPoints", "SmallIcon", "StackSize" },
                values: new object[] { "Desc_OreCopper_C", "IconDesc_copper_new_256", "Used for crafting.\r\nBasic resource mainly used for electricity.", "Copper Ore", "#00000000", 2, "#00000000", false, false, 3, "IconDesc_copper_new_64", 100 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BigIcon", "Description", "DisplayName", "FluidColorHexa", "Form", "GasColorHexa", "IsEvent", "IsRadioactive", "ResourceSinkPoints", "SmallIcon", "StackSize" },
                values: new object[] { "Desc_OreGold_C", "IconDesc_CateriumOre_256", "Caterium Ore is smelted into Caterium Ingots. Caterium Ingots are mostly used for advanced electronics.", "Caterium Ore", "#00000000", 2, "#00000000", false, false, 7, "IconDesc_CateriumOre_64", 100 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BigIcon", "Description", "DisplayName", "FluidColorHexa", "Form", "GasColorHexa", "IsEvent", "IsRadioactive", "ResourceSinkPoints", "SmallIcon", "StackSize" },
                values: new object[] { "Desc_OreIron_C", "IconDesc_iron_new_256", "Used for crafting.\r\nThe most essential basic resource.", "Iron Ore", "#00000000", 2, "#00000000", false, false, 1, "IconDesc_iron_new_64", 100 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BigIcon", "Description", "DisplayName", "FluidColorHexa", "Form", "GasColorHexa", "IsEvent", "IsRadioactive", "ResourceSinkPoints", "SmallIcon", "StackSize" },
                values: new object[] { "Desc_OreUranium_C", "IconDesc_UraniumOre_256", "Uranium is a radioactive element. \r\nUsed to produce Encased Uranium Cells for Uranium Fuel Rods.\r\n\r\nCaution: Moderately Radioactive.", "Uranium", "#00000000", 2, "#00000000", false, true, 35, "IconDesc_UraniumOre_64", 100 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BigIcon", "Description", "DisplayName", "FluidColorHexa", "Form", "GasColorHexa", "IsEvent", "IsRadioactive", "ResourceSinkPoints", "SmallIcon", "StackSize" },
                values: new object[] { "Desc_PackagedAlumina_C", "IconDesc_PackagedAluminaSolution_256", "Alumina Solution, packaged for alternative transport.", "Packaged Alumina Solution", "#3A532AFF", 2, "#00000000", false, false, 160, "IconDesc_PackagedAluminaSolution_64", 100 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BigIcon", "Description", "DisplayName", "FluidColorHexa", "Form", "GasColorHexa", "IsEvent", "IsRadioactive", "ResourceSinkPoints", "SmallIcon", "StackSize" },
                values: new object[] { "Desc_PackagedBiofuel_C", "IconDesc_LiquidBiofuel_256", "Liquid Biofuel, packaged for alternative transport. Can be used as fuel for Vehicles.", "Packaged Liquid Biofuel", "#3A532AFF", 2, "#00000000", false, false, 370, "IconDesc_LiquidBiofuel_64", 100 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BigIcon", "Description", "DisplayName", "FluidColorHexa", "Form", "GasColorHexa", "IsEvent", "IsRadioactive", "ResourceSinkPoints", "SmallIcon", "StackSize" },
                values: new object[] { "Desc_PackagedNitricAcid_C", "IconDesc_PackagedNitricAcid_256", "Nitric Acid, packaged for alternative transport.", "Packaged Nitric Acid", "#3A532AFF", 2, "#00000000", false, false, 412, "IconDesc_PackagedNitricAcid_64", 100 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BigIcon", "Description", "DisplayName", "FluidColorHexa", "Form", "GasColorHexa", "IsEvent", "IsRadioactive", "ResourceSinkPoints", "SmallIcon", "StackSize" },
                values: new object[] { "Desc_PackagedNitrogenGas_C", "IconDesc_PackagedNitrogen_256", "Nitrogen Gas, packaged for alternative transport.", "Packaged Nitrogen Gas", "#3A532AFF", 2, "#00000000", false, false, 312, "IconDesc_PackagedNitrogen_64", 100 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BigIcon", "Description", "DisplayName", "FluidColorHexa", "Form", "GasColorHexa", "IsEvent", "IsRadioactive", "ResourceSinkPoints", "SmallIcon", "StackSize" },
                values: new object[] { "Desc_PackagedOil_C", "Oil_256", "Crude Oil, packaged for alternative transport. Can be used as fuel for Vehicles.", "Packaged Oil", "#00000000", 2, "#00000000", false, false, 180, "Oil_64", 100 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BigIcon", "Description", "DisplayName", "FluidColorHexa", "Form", "GasColorHexa", "IsEvent", "IsRadioactive", "ResourceSinkPoints", "SmallIcon", "StackSize" },
                values: new object[] { "Desc_PackagedOilResidue_C", "OilResidue_256", "Heavy Oil Residue, packaged for alternative transport. Can be used as fuel for Vehicles.", "Packaged Heavy Oil Residue", "#6D2D78FF", 2, "#00000000", false, false, 180, "OilResidue_64", 100 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BigIcon", "Description", "DisplayName", "FluidColorHexa", "Form", "GasColorHexa", "IsEvent", "IsRadioactive", "ResourceSinkPoints", "SmallIcon", "StackSize" },
                values: new object[] { "Desc_PackagedSulfuricAcid_C", "IconDesc_PckagedSulphuricAcid_256", "Sulfuric Acid, packaged for alternative transport.", "Packaged Sulfuric Acid", "#3A532AFF", 2, "#00000000", false, false, 152, "IconDesc_PckagedSulphuricAcid_64", 100 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BigIcon", "Description", "DisplayName", "FluidColorHexa", "Form", "GasColorHexa", "IsEvent", "IsRadioactive", "ResourceSinkPoints", "SmallIcon", "StackSize" },
                values: new object[] { "Desc_PackagedWater_C", "IconDesc_PackagedWater_256", "Water, packaged for alternative transport.", "Packaged Water", "#7AB0D4FF", 2, "#00000000", false, false, 130, "IconDesc_PackagedWater_64", 100 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BigIcon", "Description", "DisplayName", "FluidColorHexa", "Form", "GasColorHexa", "IsEvent", "IsRadioactive", "ResourceSinkPoints", "SmallIcon", "StackSize" },
                values: new object[] { "Desc_Parachute_C", "Parachute_256", "Slot: Body\r\nConsumable\r\n\r\nSlows down your fall when activated in mid-air.", "Parachute", "#00000000", 2, "#00000000", false, false, 608, "Parachute_64", 50 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BigIcon", "Description", "DisplayName", "FluidColorHexa", "Form", "GasColorHexa", "IsEvent", "IsRadioactive", "ResourceSinkPoints", "SmallIcon", "StackSize" },
                values: new object[] { "Desc_PetroleumCoke_C", "IconDesc_PetroleumCoke_256", "Used for crafting.\r\nA carbon-rich material distilled from Heavy Oil Residue. \r\nUsed as a less efficient coal replacement or for aluminum refinement.", "Petroleum Coke", "#00000000", 2, "#00000000", false, false, 20, "IconDesc_PetroleumCoke_64", 200 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BigIcon", "Description", "DisplayName", "FluidColorHexa", "Form", "GasColorHexa", "IsEvent", "IsRadioactive", "ResourceSinkPoints", "SmallIcon", "StackSize" },
                values: new object[] { "Desc_Plastic_C", "IconDesc_Plastic_256", "A versatile and easy to manufacture material that can be used for a lot of things.", "Plastic", "#00000000", 2, "#00000000", false, false, 75, "IconDesc_Plastic_64", 200 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BigIcon", "Description", "DisplayName", "FluidColorHexa", "Form", "GasColorHexa", "IsEvent", "IsRadioactive", "ResourceSinkPoints", "SmallIcon", "StackSize" },
                values: new object[] { "Desc_PlutoniumCell_C", "IconDesc_EncasedPlutoniumCell_256", "Plutonium Cells are concrete encased Plutonium Pellets.\r\nUsed to produce Plutonium Fuel Rods for Nuclear Power production.\r\n\r\nCaution: Moderately Radioactive.", "Encased Plutonium Cell", "#00000000", 2, "#00000000", false, true, 0, "IconDesc_EncasedPlutoniumCell_64", 200 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BigIcon", "Description", "DisplayName", "FluidColorHexa", "Form", "GasColorHexa", "IsEvent", "IsRadioactive", "ResourceSinkPoints", "SmallIcon", "StackSize" },
                values: new object[] { "Desc_PlutoniumFuelRod_C", "IconDesc_PlutoniumFuelRod_256", "Used as fuel for the Nuclear Power Plant.\r\n\r\nCaution: Produces radioactive Plutonium Waste when consumed.\r\nCaution: HIGHLY Radioactive.", "Plutonium Fuel Rod", "#00000000", 2, "#00000000", false, true, 153184, "IconDesc_PlutoniumFuelRod_64", 50 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BigIcon", "Description", "DisplayName", "FluidColorHexa", "Form", "GasColorHexa", "IsEvent", "IsRadioactive", "ResourceSinkPoints", "SmallIcon", "StackSize" },
                values: new object[] { "Desc_PlutoniumPellet_C", "IconDesc_PlutoniumPellet_256", "Produced in the Particle Accelerator through conversion of Non-fissile Uranium.\r\nUsed to produce Encased Plutonium Cells for Plutonium Fuel Rods.\r\n\r\nPower Usage: 250-750 MW (500 MW average).\r\nCaution: Moderately Radioactive.", "Plutonium Pellet", "#00000000", 2, "#00000000", false, true, 0, "IconDesc_PlutoniumPellet_64", 100 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BigIcon", "Description", "DisplayName", "FluidColorHexa", "Form", "GasColorHexa", "IsEvent", "IsRadioactive", "ResourceSinkPoints", "SmallIcon", "StackSize" },
                values: new object[] { "Desc_PlutoniumWaste_C", "IconDesc_PlutoniumWaste_256", "The by-product of consuming Plutonium Fuel Rods in the Nuclear Power Plant.\r\nNeeds to be stored in a safe location. Handle with caution.\r\n\r\nCaution: EXTREMELY Radioactive.", "Plutonium Waste", "#00000000", 2, "#00000000", false, true, 0, "IconDesc_PlutoniumWaste_64", 500 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BigIcon", "Description", "DisplayName", "FluidColorHexa", "Form", "GasColorHexa", "IsEvent", "IsRadioactive", "ResourceSinkPoints", "SmallIcon", "StackSize" },
                values: new object[] { "Desc_PolymerResin_C", "IconDesc_PolymerResin_256", "Used for crafting.\r\nA by-product of oil refinement into fuel. Commonly used to manufacture plastics.", "Polymer Resin", "#00000000", 2, "#00000000", false, false, 12, "IconDesc_PolymerResin_64", 200 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BigIcon", "Description", "DisplayName", "FluidColorHexa", "Form", "GasColorHexa", "IsEvent", "IsRadioactive", "ResourceSinkPoints", "SmallIcon", "StackSize" },
                values: new object[] { "Desc_PressureConversionCube_C", "IconDesc_ConversionCube_256", "Converts outgoing force into internal pressure. Required to contain unstable, high-energy matter.", "Pressure Conversion Cube", "#00000000", 2, "#00000000", false, false, 257312, "IconDesc_ConversionCube_64", 50 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BigIcon", "Description", "DisplayName", "FluidColorHexa", "Form", "GasColorHexa", "IsEvent", "IsRadioactive", "ResourceSinkPoints", "SmallIcon", "StackSize" },
                values: new object[] { "Desc_QuartzCrystal_C", "IconDesc_QuartzResource_256", "Derived from Raw Quartz. Used in the production of advanced radar technology and high-quality display screens.", "Quartz Crystal", "#00000000", 2, "#00000000", false, false, 50, "IconDesc_QuartzResource_64", 100 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BigIcon", "Description", "DisplayName", "FluidColorHexa", "Form", "GasColorHexa", "IsEvent", "IsRadioactive", "ResourceSinkPoints", "SmallIcon", "StackSize" },
                values: new object[] { "Desc_RawQuartz_C", "IconDesc_QuartzCrystal_256", "Raw Quartz can be processed into Quartz Crystals and Silica, which both offer a variety of applications.", "Raw Quartz", "#00000000", 2, "#00000000", false, false, 15, "IconDesc_QuartzCrystal_64", 100 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BigIcon", "Description", "DisplayName", "FluidColorHexa", "Form", "GasColorHexa", "IsEvent", "IsRadioactive", "ResourceSinkPoints", "SmallIcon", "StackSize" },
                values: new object[] { "Desc_RebarGunProjectile_C", "RebarGun_256", "Slot: Hands\r\nAmmo: Spiked Rebar\r\n\r\nImprovised ranged weapon for self defense. Has to be reloaded after each use.", "Rebar Gun", "#00000000", 2, "#00000000", false, false, 1968, "RebarGun_64", 1 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BigIcon", "Description", "DisplayName", "FluidColorHexa", "Form", "GasColorHexa", "IsEvent", "IsRadioactive", "ResourceSinkPoints", "SmallIcon", "StackSize" },
                values: new object[] { "Desc_Rotor_C", "IconDesc_Rotor_256", "Used for crafting.\r\nThe moving parts of a motor.", "Rotor", "#00000000", 2, "#00000000", false, false, 140, "IconDesc_Rotor_64", 100 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BigIcon", "Description", "DisplayName", "FluidColorHexa", "Form", "GasColorHexa", "IsEvent", "IsRadioactive", "ResourceSinkPoints", "SmallIcon", "StackSize" },
                values: new object[] { "Desc_Rubber_C", "IconDesc_Rubber_256", "Rubber is a material that is very flexible and has a lot of friction.", "Rubber", "#00000000", 2, "#00000000", false, false, 60, "IconDesc_Rubber_64", 200 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BigIcon", "Description", "DisplayName", "FluidColorHexa", "Form", "GasColorHexa", "IsEvent", "IsRadioactive", "ResourceSinkPoints", "SmallIcon", "StackSize" },
                values: new object[] { "Desc_Shroom_C", "Mushroom_256", "Slot: Hands\r\nConsumable\r\n\r\nCan be eaten to restore two health segments.", "Bacon Agaric", "#00000000", 2, "#00000000", false, false, 0, "Mushroom_64", 50 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BigIcon", "Description", "DisplayName", "FluidColorHexa", "Form", "GasColorHexa", "IsEvent", "IsRadioactive", "ResourceSinkPoints", "SmallIcon", "StackSize" },
                values: new object[] { "Desc_Silica_C", "IconDesc_Silica_256", "Derived from Raw Quartz. Commonly used to create glass structures, advanced refinement processes, and alternative production of electronics.", "Silica", "#00000000", 2, "#00000000", false, false, 20, "IconDesc_Silica_64", 200 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BigIcon", "Description", "DisplayName", "FluidColorHexa", "Form", "GasColorHexa", "IsEvent", "IsRadioactive", "ResourceSinkPoints", "SmallIcon", "StackSize" },
                values: new object[] { "Desc_Snow_C", "IconDesc_Snow_256", "It's snow. Not the nice, thick, crunchy kind though... more the disgustingly wet, slushy kind... Guess we can make stuff from it.", "Actual Snow", "#00000000", 2, "#00000000", true, false, 1, "IconDesc_Snow_64", 500 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BigIcon", "Description", "DisplayName", "FluidColorHexa", "Form", "GasColorHexa", "IsEvent", "IsRadioactive", "ResourceSinkPoints", "SmallIcon", "StackSize" },
                values: new object[] { "Desc_SnowballProjectile_C", "IconDesc_SnowballProjectile_256", "Compressed dihydrogen monoxide crystals.\r\n\r\nAlternative Nobelisk Ammo. Use G to swap!", "Snowball", "#00000000", 2, "#00000000", true, false, 1, "IconDesc_SnowballProjectile_64", 500 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BigIcon", "Description", "DisplayName", "FluidColorHexa", "Form", "GasColorHexa", "IsEvent", "IsRadioactive", "ResourceSinkPoints", "SmallIcon", "StackSize" },
                values: new object[] { "Desc_SpaceElevatorPart_1_C", "IconDesc_SpelevatorPart_1_256", "Project Part #1. Ship with the Space Elevator to complete phases of Project Assembly.", "Smart Plating", "#00000000", 2, "#00000000", false, false, 520, "IconDesc_SpelevatorPart_1_64", 50 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BigIcon", "Description", "DisplayName", "FluidColorHexa", "Form", "GasColorHexa", "IsEvent", "IsRadioactive", "ResourceSinkPoints", "SmallIcon", "StackSize" },
                values: new object[] { "Desc_SpaceElevatorPart_2_C", "IconDesc_SpelevatorPart_2_256", "Project Part #2. Ship with the Space Elevator to complete phases of Project Assembly.", "Versatile Framework", "#00000000", 2, "#00000000", false, false, 1176, "IconDesc_SpelevatorPart_2_64", 50 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BigIcon", "Description", "DisplayName", "FluidColorHexa", "Form", "GasColorHexa", "IsEvent", "IsRadioactive", "ResourceSinkPoints", "SmallIcon", "StackSize" },
                values: new object[] { "Desc_SpaceElevatorPart_3_C", "SpelevatorPart_3_256", "Project Part #3. Ship with the Space Elevator to complete phases of Project Assembly.", "Automated Wiring", "#00000000", 2, "#00000000", false, false, 1440, "SpelevatorPart_3_64", 50 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BigIcon", "Description", "DisplayName", "FluidColorHexa", "Form", "GasColorHexa", "IsEvent", "IsRadioactive", "ResourceSinkPoints", "SmallIcon", "StackSize" },
                values: new object[] { "Desc_SpaceElevatorPart_4_C", "IconDesc_SpelevatorPart_4_256", "Project Part #4. Ship with the Space Elevator to complete phases of Project Assembly.", "Modular Engine", "#00000000", 2, "#00000000", false, false, 9960, "IconDesc_SpelevatorPart_4_64", 50 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BigIcon", "Description", "DisplayName", "FluidColorHexa", "Form", "GasColorHexa", "IsEvent", "IsRadioactive", "ResourceSinkPoints", "SmallIcon", "StackSize" },
                values: new object[] { "Desc_SpaceElevatorPart_5_C", "IconDesc_SpelevatorPart_5_256", "Project Part #5. Ship with the Space Elevator to complete phases of Project Assembly.", "Adaptive Control Unit", "#00000000", 2, "#00000000", false, false, 86120, "IconDesc_SpelevatorPart_5_64", 50 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BigIcon", "Description", "DisplayName", "FluidColorHexa", "Form", "GasColorHexa", "IsEvent", "IsRadioactive", "ResourceSinkPoints", "SmallIcon", "StackSize" },
                values: new object[] { "Desc_SpaceElevatorPart_6_C", "IconDesc_MagneticFieldGenerator_256", "Project Part #7. Ship with the Space Elevator to complete phases of Project Assembly.\r\n\r\nThese modular generators use superconducting magnets and vast amounts of electricity to produce an easily expandable and powerful magnetic field.", "Magnetic Field Generator", "#00000000", 2, "#00000000", false, false, 15650, "IconDesc_MagneticFieldGenerator_64", 50 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BigIcon", "Description", "DisplayName", "FluidColorHexa", "Form", "GasColorHexa", "IsEvent", "IsRadioactive", "ResourceSinkPoints", "SmallIcon", "StackSize" },
                values: new object[] { "Desc_SpaceElevatorPart_7_C", "IconDesc_AssemblyDirectorSystem_256", "Project Part #6. Ship with the Space Elevator to complete phases of Project Assembly.\r\n\r\nThis extremely fast and precise computing system is specifically designed to direct the Project Assembly: Assembly Phase.", "Assembly Director System", "#00000000", 2, "#00000000", false, false, 543632, "IconDesc_AssemblyDirectorSystem_64", 50 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BigIcon", "Description", "DisplayName", "FluidColorHexa", "Form", "GasColorHexa", "IsEvent", "IsRadioactive", "ResourceSinkPoints", "SmallIcon", "StackSize" },
                values: new object[] { "Desc_SpaceElevatorPart_8_C", "IconDesc_ThermalPropulsionRocket_256", "Project Part #8. Ship with the Space Elevator to complete phases of Project Assembly.\r\n\r\nUses extreme heat to produce the high pressure plasma required to get Project Assembly into motion.", "Thermal Propulsion Rocket", "#00000000", 2, "#00000000", false, false, 732956, "IconDesc_ThermalPropulsionRocket_64", 50 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BigIcon", "Description", "DisplayName", "FluidColorHexa", "Form", "GasColorHexa", "IsEvent", "IsRadioactive", "ResourceSinkPoints", "SmallIcon", "StackSize" },
                values: new object[] { "Desc_SpaceElevatorPart_9_C", "IconDesc_NuclearPasta_256", "Project Part #9. Ship with the Space Elevator to complete phases of Project Assembly.\r\nPower Usage: 500-1500 MW (1000 MW average).\r\n\r\nNuclear Pasta is extremely dense degenerate matter, formed when extreme pressure forces protons and electrons together into neutrons. It is theorized to exist naturally within the crust of neutron stars.", "Nuclear Pasta", "#00000000", 2, "#00000000", false, false, 543424, "IconDesc_NuclearPasta_64", 50 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BigIcon", "Description", "DisplayName", "FluidColorHexa", "Form", "GasColorHexa", "IsEvent", "IsRadioactive", "ResourceSinkPoints", "SmallIcon", "StackSize" },
                values: new object[] { "Desc_SpikedRebar_C", "IconDesc_SpikedRebar_256", "Ammo for the Rebar Gun.", "Spiked Rebar", "#00000000", 2, "#00000000", false, false, 8, "IconDesc_SpikedRebar_64", 50 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BigIcon", "Description", "DisplayName", "FluidColorHexa", "Form", "GasColorHexa", "IsEvent", "IsRadioactive", "ResourceSinkPoints", "SmallIcon", "StackSize" },
                values: new object[] { "Desc_SpitterParts_C", "IconDesc_SpitterPart_256", "Organs from alien creatures.", "Alien Organs", "#00000000", 2, "#00000000", false, false, 0, "IconDesc_SpitterPart_64", 50 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BigIcon", "Description", "DisplayName", "FluidColorHexa", "Form", "GasColorHexa", "IsEvent", "IsRadioactive", "ResourceSinkPoints", "SmallIcon", "StackSize" },
                values: new object[] { "Desc_Stator_C", "IconDesc_Stator_256", "Used for crafting.\r\nThe static parts of a motor.", "Stator", "#00000000", 2, "#00000000", false, false, 240, "IconDesc_Stator_64", 100 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BigIcon", "Description", "DisplayName", "FluidColorHexa", "Form", "GasColorHexa", "IsEvent", "IsRadioactive", "ResourceSinkPoints", "SmallIcon", "StackSize" },
                values: new object[] { "Desc_SteelIngot_C", "IconDesc_SteelIngot_256", "Steel Ingots are made from Iron Ore that's been smelted with Coal. They are made into several parts used in building construction.", "Steel Ingot", "#00000000", 2, "#00000000", false, false, 8, "IconDesc_SteelIngot_64", 100 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BigIcon", "Description", "DisplayName", "FluidColorHexa", "Form", "GasColorHexa", "IsEvent", "IsRadioactive", "ResourceSinkPoints", "SmallIcon", "StackSize" },
                values: new object[] { "Desc_SteelPipe_C", "IconDesc_SteelPipe_256", "Steel Pipes are used most often when constructing a little more advanced buildings.", "Steel Pipe", "#00000000", 2, "#00000000", false, false, 24, "IconDesc_SteelPipe_64", 200 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BigIcon", "Description", "DisplayName", "FluidColorHexa", "Form", "GasColorHexa", "IsEvent", "IsRadioactive", "ResourceSinkPoints", "SmallIcon", "StackSize" },
                values: new object[] { "Desc_SteelPlate_C", "IconDesc_SteelBeam_256", "Steel Beams are used most often when constructing a little more advanced buildings.", "Steel Beam", "#00000000", 2, "#00000000", false, false, 64, "IconDesc_SteelBeam_64", 200 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BigIcon", "Description", "DisplayName", "FluidColorHexa", "Form", "GasColorHexa", "IsEvent", "IsRadioactive", "ResourceSinkPoints", "SmallIcon", "StackSize" },
                values: new object[] { "Desc_SteelPlateReinforced_C", "IconDesc_EncasedSteelBeam_256", "Encased Industrial Beams utilizes the compressive strength of concrete and tensile strength of steel simultaneously.\r\nMostly used as a stable basis for constructing buildings.", "Encased Industrial Beam", "#00000000", 2, "#00000000", false, false, 632, "IconDesc_EncasedSteelBeam_64", 100 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BigIcon", "Description", "DisplayName", "FluidColorHexa", "Form", "GasColorHexa", "IsEvent", "IsRadioactive", "ResourceSinkPoints", "SmallIcon", "StackSize" },
                values: new object[] { "Desc_Stone_C", "Stone_256", "Used for crafting.\r\nBasic resource mainly used for stable foundations.", "Limestone", "#00000000", 2, "#00000000", false, false, 2, "Stone_64", 100 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BigIcon", "Description", "DisplayName", "FluidColorHexa", "Form", "GasColorHexa", "IsEvent", "IsRadioactive", "ResourceSinkPoints", "SmallIcon", "StackSize" },
                values: new object[] { "Desc_Sulfur_C", "Sulfur_256", "Sulfur is primarily used for Black Powder.", "Sulfur", "#00000000", 2, "#00000000", false, false, 11, "Sulfur_64", 100 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BigIcon", "Description", "DisplayName", "FluidColorHexa", "Form", "GasColorHexa", "IsEvent", "IsRadioactive", "ResourceSinkPoints", "SmallIcon", "StackSize" },
                values: new object[] { "Desc_SulfuricAcid_C", "IconDesc_LiquidSulfuricAcid_Pipe_512", "A mineral acid produced by combining Sulfur and Water in a complex reaction. Primarily used in refinement processes and Battery production.", "Sulfuric Acid", "#FFFF00FF", 3, "#00000000", false, false, 16, "IconDesc_LiquidSulfuricAcid_Pipe_256", 0 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BigIcon", "Description", "DisplayName", "FluidColorHexa", "Form", "GasColorHexa", "IsEvent", "IsRadioactive", "ResourceSinkPoints", "SmallIcon", "StackSize" },
                values: new object[] { "Desc_TurboFuel_C", "IconDesc_TurboFuel_256", "Turbofuel, packaged for alternative transport. Can be used as fuel for Vehicles.", "Packaged Turbofuel", "#D4292EFF", 2, "#00000000", false, false, 570, "IconDesc_TurboFuel_64", 100 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BigIcon", "Description", "DisplayName", "FluidColorHexa", "Form", "GasColorHexa", "IsEvent", "IsRadioactive", "ResourceSinkPoints", "SmallIcon", "StackSize" },
                values: new object[] { "Desc_UraniumCell_C", "IconDesc_NuclearCell_256", "Uranium Cells are produced from Uranium Ore. \r\nUsed to produce Uranium Fuel Rods for Nuclear Power production.\r\n\r\nCaution: Mildly Radioactive.", "Encased Uranium Cell", "#00000000", 2, "#00000000", false, true, 147, "IconDesc_NuclearCell_64", 200 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BigIcon", "Description", "DisplayName", "FluidColorHexa", "Form", "GasColorHexa", "IsEvent", "IsRadioactive", "ResourceSinkPoints", "SmallIcon", "StackSize" },
                values: new object[] { "Desc_Water_C", "LiquidWater_Pipe_512", "It's water.", "Water", "#7AB0D4FF", 3, "#00000000", false, false, 5, "LiquidWater_Pipe_256", 0 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BigIcon", "Description", "DisplayName", "FluidColorHexa", "Form", "GasColorHexa", "IsEvent", "IsRadioactive", "ResourceSinkPoints", "SmallIcon", "StackSize" },
                values: new object[] { "Desc_Wire_C", "IconDesc_Wire_256", "Used for crafting.\r\nOne of the most basic parts.", "Wire", "#00000000", 2, "#00000000", false, false, 6, "IconDesc_Wire_64", 500 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BigIcon", "Description", "DisplayName", "FluidColorHexa", "Form", "GasColorHexa", "IsEvent", "IsRadioactive", "ResourceSinkPoints", "SmallIcon", "StackSize" },
                values: new object[] { "Desc_Wood_C", "IconDesc_Wood_256", "Primarily used as fuel.\r\nBiomass Burners and vehicles can use it for power.", "Wood", "#00000000", 2, "#00000000", false, false, 30, "IconDesc_Wood_64", 200 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BigIcon", "Description", "DisplayName", "FluidColorHexa", "Form", "GasColorHexa", "IsEvent", "IsRadioactive", "ResourceSinkPoints", "SmallIcon", "StackSize" },
                values: new object[] { "Desc_XmasBall1_C", "IconDesc_XmasBall_Red_256", "Used for making FICSMAS Decorations.", "Red FICSMAS Ornament", "#00000000", 2, "#00000000", true, false, 1, "IconDesc_XmasBall_Red_64", 500 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BigIcon", "Description", "DisplayName", "FluidColorHexa", "Form", "GasColorHexa", "IsEvent", "IsRadioactive", "ResourceSinkPoints", "SmallIcon", "StackSize" },
                values: new object[] { "Desc_XmasBall2_C", "IconDesc_XmasBall_Blue_256", "Again, used for making FICSMAS Decorations.", "Blue FICSMAS Ornament", "#00000000", 2, "#00000000", true, false, 1, "IconDesc_XmasBall_Blue_64", 500 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BigIcon", "Description", "DisplayName", "FluidColorHexa", "Form", "GasColorHexa", "IsEvent", "IsRadioactive", "ResourceSinkPoints", "SmallIcon", "StackSize" },
                values: new object[] { "Desc_XmasBall3_C", "IconDesc_XmasBall_Yellow_256", "Still used for making FICSMAS Decorations.", "Copper FICSMAS Ornament", "#00000000", 2, "#00000000", true, false, 1, "IconDesc_XmasBall_Yellow_64", 200 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BigIcon", "Description", "DisplayName", "FluidColorHexa", "Form", "GasColorHexa", "IsEvent", "IsRadioactive", "ResourceSinkPoints", "SmallIcon", "StackSize" },
                values: new object[] { "Desc_XmasBall4_C", "IconDesc_XmasBall_Silver_256", "This super special... nope... still just used for making FICSMAS Decorations.", "Iron FICSMAS Ornament", "#00000000", 2, "#00000000", true, false, 1, "IconDesc_XmasBall_Silver_64", 200 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BigIcon", "Description", "DisplayName", "FluidColorHexa", "Form", "GasColorHexa", "IsEvent", "IsRadioactive", "ResourceSinkPoints", "SmallIcon", "StackSize" },
                values: new object[] { "Desc_XmasBallCluster_C", "IconDesc_Balls_256", "All the FICSMAS Ornaments smashed together to make even more FICSMAS Decorations!", "FICSMAS Ornament Bundle", "#00000000", 2, "#00000000", true, false, 1, "IconDesc_Balls_64", 100 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BigIcon", "Description", "DisplayName", "FluidColorHexa", "Form", "GasColorHexa", "IsEvent", "IsRadioactive", "ResourceSinkPoints", "SmallIcon", "StackSize" },
                values: new object[] { "Desc_XmasBow_C", "IconDesc_Bow_256", "A fancy Bow, maybe someone can wear this? You certainly can't! Probably, some parts and decorations can be made from this.", "FICSMAS Bow", "#00000000", 2, "#00000000", true, false, 1, "IconDesc_Bow_64", 500 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BigIcon", "Description", "DisplayName", "FluidColorHexa", "Form", "GasColorHexa", "IsEvent", "IsRadioactive", "ResourceSinkPoints", "SmallIcon", "StackSize" },
                values: new object[] { "Desc_XmasBranch_C", "IconDesc_Branch_256", "A special Tree Branch, used to produce parts and buildings during the FICSMAS Event.", "FICSMAS Tree Branch", "#00000000", 2, "#00000000", true, false, 1, "IconDesc_Branch_64", 500 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BigIcon", "Description", "DisplayName", "FluidColorHexa", "Form", "GasColorHexa", "IsEvent", "IsRadioactive", "ResourceSinkPoints", "SmallIcon", "StackSize" },
                values: new object[] { "Desc_XmasStar_C", "IconDesc_Star_256", "This special FICSMAS Star signifies the productivity of FICSIT all across the universe. It also signifies the fact that you have nearly completed the Holiday Event, so it's time to get back to work.", "FICSMAS Wonder Star", "#00000000", 2, "#00000000", true, false, 1, "IconDesc_Star_64", 50 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "BigIcon", "Description", "DisplayName", "FluidColorHexa", "Form", "GasColorHexa", "IsEvent", "IsRadioactive", "ResourceSinkPoints", "SmallIcon", "StackSize" },
                values: new object[] { "Desc_XmasWreath_C", "IconDesc_Wreath_256", "A decoration used to make decorations. Its use cases are questionable.", "FICSMAS Decoration", "#00000000", 2, "#00000000", true, false, 1, "IconDesc_Wreath_64", 100 });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_AILimiter_C", "AI Limiter", false, 1f, 12f, "Build_AssemblerMk1_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_Alternate_AdheredIronPlate_C", "Alternate: Adhered Iron Plate", true, 1f, 16f, "Build_AssemblerMk1_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_Alternate_AlcladCasing_C", "Alternate: Alclad Casing", true, 1f, 8f, "Build_AssemblerMk1_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_Alternate_AutomatedMiner_C", "Alternate: Automated Miner", true, 1f, 60f, "Build_ManufacturerMk1_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_Alternate_Beacon_1_C", "Alternate: Crystal Beacon", true, 1f, 120f, "Build_ManufacturerMk1_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_Alternate_BoltedFrame_C", "Alternate: Bolted Frame", true, 1f, 24f, "Build_AssemblerMk1_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_Alternate_Cable_1_C", "Alternate: Insulated Cable", true, 1f, 12f, "Build_AssemblerMk1_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_Alternate_Cable_2_C", "Alternate: Quickwire Cable", true, 1f, 24f, "Build_AssemblerMk1_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_Alternate_CircuitBoard_1_C", "Alternate: Silicon Circuit Board", true, 1f, 24f, "Build_AssemblerMk1_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_Alternate_CircuitBoard_2_C", "Alternate: Caterium Circuit Board", true, 1f, 48f, "Build_AssemblerMk1_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_Alternate_ClassicBattery_C", "Alternate: Classic Battery", true, 1f, 8f, "Build_ManufacturerMk1_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_Alternate_Coal_1_C", "Alternate: Charcoal", true, 1f, 4f, "Build_ConstructorMk1_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_Alternate_Coal_2_C", "Alternate: Biocoal", true, 1f, 8f, "Build_ConstructorMk1_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_Alternate_CoatedCable_C", "Alternate: Coated Cable", true, 1f, 8f, "Build_OilRefinery_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_Alternate_CoatedIronCanister_C", "Alternate: Coated Iron Canister", true, 1f, 4f, "Build_AssemblerMk1_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_Alternate_CoatedIronPlate_C", "Alternate: Coated Iron Plate", true, 1f, 12f, "Build_AssemblerMk1_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_Alternate_CokeSteelIngot_C", "Alternate: Coke Steel Ingot", true, 1f, 12f, "Build_FoundryMk1_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_Alternate_Computer_1_C", "Alternate: Caterium Computer", true, 1f, 16f, "Build_ManufacturerMk1_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_Alternate_Computer_2_C", "Alternate: Crystal Computer", true, 1f, 64f, "Build_AssemblerMk1_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_Alternate_Concrete_C", "Alternate: Fine Concrete", true, 1f, 24f, "Build_AssemblerMk1_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_Alternate_CoolingDevice_C", "Alternate: Cooling Device", true, 1f, 32f, "Build_Blender_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_Alternate_CopperAlloyIngot_C", "Alternate: Copper Alloy Ingot", true, 1f, 12f, "Build_FoundryMk1_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_Alternate_CopperRotor_C", "Alternate: Copper Rotor", true, 1f, 16f, "Build_AssemblerMk1_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_Alternate_CrystalOscillator_C", "Alternate: Insulated Crystal Oscillator", true, 1f, 32f, "Build_ManufacturerMk1_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_Alternate_DilutedFuel_C", "Alternate: Diluted Fuel", true, 1f, 6f, "Build_Blender_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_Alternate_DilutedPackagedFuel_C", "Alternate: Diluted Packaged Fuel", true, 1f, 2f, "Build_OilRefinery_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_Alternate_ElectricMotor_C", "Alternate: Electric Motor", true, 1f, 16f, "Build_AssemblerMk1_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_Alternate_ElectroAluminumScrap_C", "Alternate: Electrode - Aluminum Scrap", true, 1f, 4f, "Build_OilRefinery_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_Alternate_ElectrodeCircuitBoard_C", "Alternate: Electrode Circuit Board", true, 1f, 12f, "Build_AssemblerMk1_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_Alternate_ElectromagneticControlRod_1_C", "Alternate: Electromagnetic Connection Rod", true, 1f, 15f, "Build_AssemblerMk1_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_Alternate_EncasedIndustrialBeam_C", "Alternate: Encased Industrial Pipe", true, 1f, 15f, "Build_AssemblerMk1_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_Alternate_EnrichedCoal_C", "Alternate: Compacted Coal", true, 1f, 12f, "Build_AssemblerMk1_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_Alternate_FertileUranium_C", "Alternate: Fertile Uranium", true, 1f, 12f, "Build_Blender_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_Alternate_FlexibleFramework_C", "Alternate: Flexible Framework", true, 1f, 16f, "Build_ManufacturerMk1_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_Alternate_FusedWire_C", "Alternate: Fused Wire", true, 1f, 20f, "Build_AssemblerMk1_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_Alternate_Gunpowder_1_C", "Alternate: Fine Black Powder", true, 1f, 16f, "Build_AssemblerMk1_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_Alternate_HeatFusedFrame_C", "Alternate: Heat-Fused Frame", true, 1f, 20f, "Build_Blender_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_Alternate_HeatSink_1_C", "Alternate: Heat Exchanger", true, 1f, 6f, "Build_AssemblerMk1_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_Alternate_HeavyFlexibleFrame_C", "Alternate: Heavy Flexible Frame", true, 1f, 16f, "Build_ManufacturerMk1_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_Alternate_HeavyOilResidue_C", "Alternate: Heavy Oil Residue", true, 1f, 6f, "Build_OilRefinery_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_Alternate_HighSpeedConnector_C", "Alternate: Silicon High-Speed Connector", true, 1f, 40f, "Build_ManufacturerMk1_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_Alternate_HighSpeedWiring_C", "Alternate: Automated Speed Wiring", true, 1f, 32f, "Build_ManufacturerMk1_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_Alternate_IngotIron_C", "Alternate: Iron Alloy Ingot", true, 1f, 6f, "Build_FoundryMk1_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_Alternate_IngotSteel_1_C", "Alternate: Solid Steel Ingot", true, 1f, 3f, "Build_FoundryMk1_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_Alternate_IngotSteel_2_C", "Alternate: Compacted Steel Ingot", true, 1f, 16f, "Build_FoundryMk1_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_Alternate_InstantScrap_C", "Alternate: Instant Scrap", true, 1f, 6f, "Build_Blender_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_Alternate_ModularFrame_C", "Alternate: Steeled Frame", true, 1f, 60f, "Build_AssemblerMk1_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_Alternate_ModularFrameHeavy_C", "Alternate: Heavy Encased Frame", true, 1f, 64f, "Build_ManufacturerMk1_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_Alternate_Motor_1_C", "Alternate: Rigour Motor", true, 1f, 48f, "Build_ManufacturerMk1_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_Alternate_Nobelisk_1_C", "Alternate: Seismic Nobelisk", true, 1f, 40f, "Build_ManufacturerMk1_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_Alternate_NuclearFuelRod_1_C", "Alternate: Uranium Fuel Unit", true, 1f, 300f, "Build_ManufacturerMk1_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_Alternate_OCSupercomputer_C", "Alternate: OC Supercomputer", true, 1f, 20f, "Build_AssemblerMk1_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_Alternate_Plastic_1_C", "Alternate: Recycled Plastic", true, 1f, 12f, "Build_OilRefinery_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_Alternate_PlasticSmartPlating_C", "Alternate: Plastic Smart Plating", true, 1f, 24f, "Build_ManufacturerMk1_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_Alternate_PlutoniumFuelUnit_C", "Alternate: Plutonium Fuel Unit", true, 1f, 120f, "Build_AssemblerMk1_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_Alternate_PolyesterFabric_C", "Alternate: Polyester Fabric", true, 1f, 12f, "Build_OilRefinery_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_Alternate_PolymerResin_C", "Alternate: Polymer Resin", true, 1f, 6f, "Build_OilRefinery_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_Alternate_PureCateriumIngot_C", "Alternate: Pure Caterium Ingot", true, 1f, 5f, "Build_OilRefinery_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_Alternate_PureCopperIngot_C", "Alternate: Pure Copper Ingot", true, 1f, 24f, "Build_OilRefinery_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_Alternate_PureIronIngot_C", "Alternate: Pure Iron Ingot", true, 1f, 12f, "Build_OilRefinery_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_Alternate_PureQuartzCrystal_C", "Alternate: Pure Quartz Crystal", true, 1f, 8f, "Build_OilRefinery_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_Alternate_Quickwire_C", "Alternate: Fused Quickwire", true, 1f, 8f, "Build_AssemblerMk1_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_Alternate_RadioControlSystem_C", "Alternate: Radio Control System", true, 1f, 40f, "Build_ManufacturerMk1_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_Alternate_RadioControlUnit_1_C", "Alternate: Radio Connection Unit", true, 1f, 16f, "Build_ManufacturerMk1_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_Alternate_RecycledRubber_C", "Alternate: Recycled Rubber", true, 1f, 12f, "Build_OilRefinery_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_Alternate_ReinforcedIronPlate_1_C", "Alternate: Bolted Iron Plate", true, 1f, 12f, "Build_AssemblerMk1_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_Alternate_ReinforcedIronPlate_2_C", "Alternate: Stitched Iron Plate", true, 1f, 32f, "Build_AssemblerMk1_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_Alternate_Rotor_C", "Alternate: Steel Rotor", true, 1f, 12f, "Build_AssemblerMk1_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_Alternate_RubberConcrete_C", "Alternate: Rubber Concrete", true, 1f, 12f, "Build_AssemblerMk1_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_Alternate_Screw_2_C", "Alternate: Steel Screw", true, 1f, 12f, "Build_ConstructorMk1_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_Alternate_Screw_C", "Alternate: Cast Screw", true, 1f, 24f, "Build_ConstructorMk1_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_Alternate_Silica_C", "Alternate: Cheap Silica", true, 1f, 16f, "Build_AssemblerMk1_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_Alternate_SloppyAlumina_C", "Alternate: Sloppy Alumina", true, 1f, 3f, "Build_OilRefinery_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_Alternate_Stator_C", "Alternate: Quickwire Stator", true, 1f, 15f, "Build_AssemblerMk1_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_Alternate_SteamedCopperSheet_C", "Alternate: Steamed Copper Sheet", true, 1f, 8f, "Build_OilRefinery_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_Alternate_SteelCanister_C", "Alternate: Steel Canister", true, 1f, 3f, "Build_ConstructorMk1_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_Alternate_SteelCoatedPlate_C", "Alternate: Steel Coated Plate", true, 1f, 24f, "Build_AssemblerMk1_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_Alternate_SteelRod_C", "Alternate: Steel Rod", true, 1f, 5f, "Build_ConstructorMk1_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_Alternate_SuperStateComputer_C", "Alternate: Super-State Computer", true, 1f, 50f, "Build_ManufacturerMk1_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_Alternate_TurboBlendFuel_C", "Alternate: Turbo Blend Fuel", true, 1f, 8f, "Build_Blender_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_Alternate_Turbofuel_C", "Turbofuel", true, 1f, 16f, "Build_OilRefinery_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_Alternate_TurboHeavyFuel_C", "Alternate: Turbo Heavy Fuel", true, 1f, 8f, "Build_OilRefinery_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_Alternate_TurboMotor_1_C", "Alternate: Turbo Electric Motor", true, 1f, 64f, "Build_ManufacturerMk1_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_Alternate_TurboPressureMotor_C", "Alternate: Turbo Pressure Motor", true, 1f, 32f, "Build_ManufacturerMk1_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_Alternate_UraniumCell_1_C", "Alternate: Infused Uranium Cell", true, 1f, 12f, "Build_ManufacturerMk1_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_Alternate_WetConcrete_C", "Alternate: Wet Concrete", true, 1f, 3f, "Build_OilRefinery_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_Alternate_Wire_1_C", "Alternate: Iron Wire", true, 1f, 24f, "Build_ConstructorMk1_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_Alternate_Wire_2_C", "Alternate: Caterium Wire", true, 1f, 4f, "Build_ConstructorMk1_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_AluminaSolution_C", "Alumina Solution", false, 1f, 6f, "Build_OilRefinery_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_AluminumCasing_C", "Aluminum Casing", false, 2f, 2f, "Build_ConstructorMk1_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_AluminumScrap_C", "Aluminum Scrap", false, 1f, 1f, "Build_OilRefinery_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_AluminumSheet_C", "Alclad Aluminum Sheet", false, 2f, 6f, "Build_AssemblerMk1_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_Battery_C", "Battery", false, 1f, 3f, "Build_Blender_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_Beacon_C", "Beacon", false, 1f, 8f, "Build_ManufacturerMk1_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_Biofuel_C", "Solid Biofuel", false, 5f, 4f, "Build_ConstructorMk1_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_Biomass_AlienCarapace_C", "Biomass (Alien Carapace)", false, 1f, 4f, "Build_ConstructorMk1_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_Biomass_AlienOrgans_C", "Biomass (Alien Organs)", false, 1f, 8f, "Build_ConstructorMk1_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_Biomass_Leaves_C", "Biomass (Leaves)", false, 0.4f, 5f, "Build_ConstructorMk1_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_Biomass_Mycelia_C", "Biomass (Mycelia)", false, 0.5f, 4f, "Build_ConstructorMk1_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_Biomass_Wood_C", "Biomass (Wood)", false, 1f, 4f, "Build_ConstructorMk1_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_Cable_C", "Cable", false, 1f, 2f, "Build_ConstructorMk1_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_CandyCane_C", "Candy Cane", false, 1f, 12f, "Build_ConstructorMk1_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_Cartridge_C", "Rifle Cartridge", false, 1f, 20f, "Build_ManufacturerMk1_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_CircuitBoard_C", "Circuit Board", false, 1.5f, 8f, "Build_AssemblerMk1_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_ColorCartridge_C", "Color Cartridge", false, 1f, 8f, "Build_ConstructorMk1_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_Computer_C", "Computer", false, 1.5f, 24f, "Build_ManufacturerMk1_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_ComputerSuper_C", "Supercomputer", false, 1.5f, 32f, "Build_ManufacturerMk1_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_Concrete_C", "Concrete", false, 1f, 4f, "Build_ConstructorMk1_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_CoolingSystem_C", "Cooling System", false, 1f, 10f, "Build_Blender_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_CopperDust_C", "Copper Powder", false, 1f, 6f, "Build_ConstructorMk1_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_CopperSheet_C", "Copper Sheet", false, 1f, 6f, "Build_ConstructorMk1_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_CrystalOscillator_C", "Crystal Oscillator", false, 0.3f, 120f, "Build_ManufacturerMk1_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_ElectromagneticControlRod_C", "Electromagnetic Control Rod", false, 1f, 30f, "Build_AssemblerMk1_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_EncasedIndustrialBeam_C", "Encased Industrial Beam", false, 1f, 10f, "Build_AssemblerMk1_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_Fabric_C", "Fabric", false, 1f, 4f, "Build_AssemblerMk1_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_FilterGasMask_C", "Gas Filter", false, 1f, 8f, "Build_ManufacturerMk1_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_FilterHazmat_C", "Iodine Infused Filter", false, 1f, 16f, "Build_ManufacturerMk1_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_Fireworks_01_C", "Sweet Fireworks", false, 1f, 24f, "Build_AssemblerMk1_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_Fireworks_02_C", "Fancy Fireworks", false, 1f, 24f, "Build_AssemblerMk1_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_Fireworks_03_C", "Sparkly Fireworks", false, 1f, 24f, "Build_AssemblerMk1_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_FluidCanister_C", "Empty Canister", false, 1f, 4f, "Build_ConstructorMk1_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_Fuel_C", "Packaged Fuel", false, 1f, 3f, "Build_Packager_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_FusedModularFrame_C", "Fused Modular Frame", false, 1f, 40f, "Build_Blender_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_GasTank_C", "Empty Fluid Tank", false, 1f, 1f, "Build_ConstructorMk1_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_Gunpowder_C", "Black Powder", false, 0.5f, 8f, "Build_AssemblerMk1_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_HeatSink_C", "Heat Sink", false, 1.5f, 8f, "Build_AssemblerMk1_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_HighSpeedConnector_C", "High-Speed Connector", false, 1f, 16f, "Build_ManufacturerMk1_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_IngotAluminum_C", "Aluminum Ingot", false, 3f, 4f, "Build_FoundryMk1_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_IngotCaterium_C", "Caterium Ingot", false, 2f, 4f, "Build_SmelterMk1_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_IngotCopper_C", "Copper Ingot", false, 3f, 2f, "Build_SmelterMk1_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_IngotIron_C", "Iron Ingot", false, 3f, 2f, "Build_SmelterMk1_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_IngotSteel_C", "Steel Ingot", false, 3f, 4f, "Build_FoundryMk1_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_IronPlate_C", "Iron Plate", false, 1f, 6f, "Build_ConstructorMk1_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_IronPlateReinforced_C", "Reinforced Iron Plate", false, 1f, 12f, "Build_AssemblerMk1_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_IronRod_C", "Iron Rod", false, 0.5f, 4f, "Build_ConstructorMk1_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_LiquidBiofuel_C", "Liquid Biofuel", false, 1f, 4f, "Build_OilRefinery_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_LiquidFuel_C", "Fuel", false, 1f, 6f, "Build_OilRefinery_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_ModularFrame_C", "Modular Frame", false, 0.5f, 60f, "Build_AssemblerMk1_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_ModularFrameHeavy_C", "Heavy Modular Frame", false, 0.6f, 30f, "Build_ManufacturerMk1_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_Motor_C", "Motor", false, 2f, 12f, "Build_AssemblerMk1_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_MotorTurbo_C", "Turbo Motor", false, 2f, 32f, "Build_ManufacturerMk1_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_NitricAcid_C", "Nitric Acid", false, 1f, 6f, "Build_Blender_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_Nobelisk_C", "Nobelisk", false, 1f, 20f, "Build_AssemblerMk1_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_NonFissileUranium_C", "Non-fissile Uranium", false, 1f, 24f, "Build_Blender_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_NuclearFuelRod_C", "Uranium Fuel Rod", false, 1f, 150f, "Build_ManufacturerMk1_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_PackagedAlumina_C", "Packaged Alumina Solution", false, 1f, 1f, "Build_Packager_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_PackagedBiofuel_C", "Packaged Liquid Biofuel", false, 1f, 3f, "Build_Packager_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_PackagedCrudeOil_C", "Packaged Oil", false, 1f, 4f, "Build_Packager_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_PackagedNitricAcid_C", "Packaged Nitric Acid", false, 1f, 2f, "Build_Packager_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_PackagedNitrogen_C", "Packaged Nitrogen Gas", false, 1f, 1f, "Build_Packager_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_PackagedOilResidue_C", "Packaged Heavy Oil Residue", false, 1f, 4f, "Build_Packager_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_PackagedSulfuricAcid_C", "Packaged Sulfuric Acid", false, 1f, 3f, "Build_Packager_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_PackagedTurboFuel_C", "Packaged Turbofuel", false, 1f, 6f, "Build_Packager_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_PackagedWater_C", "Packaged Water", false, 1f, 2f, "Build_Packager_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_PetroleumCoke_C", "Petroleum Coke", false, 1f, 6f, "Build_OilRefinery_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_Plastic_C", "Plastic", false, 1f, 6f, "Build_OilRefinery_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_PlutoniumCell_C", "Encased Plutonium Cell", false, 0.5f, 12f, "Build_AssemblerMk1_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_PlutoniumFuelRod_C", "Plutonium Fuel Rod", false, 1f, 240f, "Build_ManufacturerMk1_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_PowerCrystalShard_1_C", "Power Shard (1)", false, 1f, 8f, "Build_ConstructorMk1_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_PowerCrystalShard_2_C", "Power Shard (2)", false, 1f, 12f, "Build_ConstructorMk1_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_PowerCrystalShard_3_C", "Power Shard (5)", false, 1f, 24f, "Build_ConstructorMk1_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_PressureConversionCube_C", "Pressure Conversion Cube", false, 2f, 60f, "Build_AssemblerMk1_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_PureAluminumIngot_C", "Alternate: Pure Aluminum Ingot", false, 1f, 2f, "Build_SmelterMk1_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_QuartzCrystal_C", "Quartz Crystal", false, 2f, 8f, "Build_ConstructorMk1_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_Quickwire_C", "Quickwire", false, 2f, 5f, "Build_ConstructorMk1_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_RadioControlUnit_C", "Radio Control Unit", false, 1f, 48f, "Build_ManufacturerMk1_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_ResidualFuel_C", "Residual Fuel", false, 1f, 6f, "Build_OilRefinery_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_ResidualPlastic_C", "Residual Plastic", false, 1f, 6f, "Build_OilRefinery_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_ResidualRubber_C", "Residual Rubber", false, 1f, 6f, "Build_OilRefinery_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_Rotor_C", "Rotor", false, 0.8f, 15f, "Build_AssemblerMk1_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_Rubber_C", "Rubber", false, 1f, 6f, "Build_OilRefinery_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_Screw_C", "Screw", false, 1f, 6f, "Build_ConstructorMk1_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_Silica_C", "Silica", false, 2f, 8f, "Build_ConstructorMk1_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_Snow_C", "Actual Snow", false, 1f, 12f, "Build_ConstructorMk1_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_Snowball_C", "Snowball", false, 1f, 12f, "Build_ConstructorMk1_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_SpaceElevatorPart_1_C", "Smart Plating", false, 1f, 30f, "Build_AssemblerMk1_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_SpaceElevatorPart_2_C", "Versatile Framework", false, 1f, 24f, "Build_AssemblerMk1_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_SpaceElevatorPart_3_C", "Automated Wiring", false, 1f, 24f, "Build_AssemblerMk1_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_SpaceElevatorPart_4_C", "Modular Engine", false, 1f, 60f, "Build_ManufacturerMk1_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_SpaceElevatorPart_5_C", "Adaptive Control Unit", false, 1f, 120f, "Build_ManufacturerMk1_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_SpaceElevatorPart_6_C", "Magnetic Field Generator", false, 1f, 120f, "Build_ManufacturerMk1_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_SpaceElevatorPart_7_C", "Assembly Director System", false, 1f, 80f, "Build_AssemblerMk1_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_SpaceElevatorPart_8_C", "Thermal Propulsion Rocket", false, 1f, 120f, "Build_ManufacturerMk1_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_SpikedRebar_C", "Spiked Rebar", false, 1f, 4f, "Build_ConstructorMk1_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_Stator_C", "Stator", false, 1.5f, 12f, "Build_AssemblerMk1_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_SteelBeam_C", "Steel Beam", false, 1f, 4f, "Build_ConstructorMk1_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_SteelPipe_C", "Steel Pipe", false, 1f, 6f, "Build_ConstructorMk1_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_SulfuricAcid_C", "Sulfuric Acid", false, 1f, 6f, "Build_OilRefinery_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_UnpackageAlumina_C", "Unpackage Alumina Solution", false, 1f, 1f, "Build_Packager_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_UnpackageBioFuel_C", "Unpackage Liquid Biofuel", false, 1f, 2f, "Build_Packager_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_UnpackageFuel_C", "Unpackage Fuel", false, 1f, 2f, "Build_Packager_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_UnpackageNitricAcid_C", "Unpackage Nitric Acid", false, 1f, 3f, "Build_Packager_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_UnpackageNitrogen_C", "Unpackage Nitrogen Gas", false, 1f, 1f, "Build_Packager_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_UnpackageOil_C", "Unpackage Oil", false, 1f, 2f, "Build_Packager_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_UnpackageOilResidue_C", "Unpackage Heavy Oil Residue", false, 1f, 6f, "Build_Packager_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_UnpackageSulfuricAcid_C", "Unpackage Sulfuric Acid", false, 1f, 1f, "Build_Packager_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_UnpackageTurboFuel_C", "Unpackage Turbofuel", false, 1f, 6f, "Build_Packager_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_UnpackageWater_C", "Unpackage Water", false, 1f, 1f, "Build_Packager_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_UraniumCell_C", "Encased Uranium Cell", false, 0.5f, 12f, "Build_Blender_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_Wire_C", "Wire", false, 1f, 4f, "Build_ConstructorMk1_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_XmasBall1_C", "Red FICSMAS Ornament", false, 1f, 12f, "Build_SmelterMk1_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_XmasBall2_C", "Blue FICSMAS Ornament", false, 1f, 12f, "Build_SmelterMk1_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_XmasBall3_C", "Copper FICSMAS Ornament", false, 1f, 12f, "Build_FoundryMk1_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_XmasBall4_C", "Iron FICSMAS Ornament", false, 1f, 12f, "Build_FoundryMk1_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_XmasBallCluster_C", "FICSMAS Ornament Bundle", false, 1f, 12f, "Build_AssemblerMk1_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_XmasBow_C", "FICSMAS Bow", false, 1f, 12f, "Build_ConstructorMk1_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_XmasBranch_C", "FICSMAS Tree Branch", false, 1f, 6f, "Build_ConstructorMk1_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_XmasStar_C", "FICSMAS Wonder Star", false, 1f, 60f, "Build_AssemblerMk1_C" });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "DisplayName", "IsAlternate", "ManualManufacturingMultiplier", "ManufactoringDuration", "ProducedInId" },
                values: new object[] { "Recipe_XmasWreath_C", "FICSMAS Decoration", false, 1f, 60f, "Build_AssemblerMk1_C" });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_CopperSheet_C", "Recipe_AILimiter_C", 5 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_HighSpeedWire_C", "Recipe_AILimiter_C", 20 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_IronPlate_C", "Recipe_Alternate_AdheredIronPlate_C", 3 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Rubber_C", "Recipe_Alternate_AdheredIronPlate_C", 1 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_AluminumIngot_C", "Recipe_Alternate_AlcladCasing_C", 20 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_CopperIngot_C", "Recipe_Alternate_AlcladCasing_C", 10 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_IronPlate_C", "Recipe_Alternate_AutomatedMiner_C", 2 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_IronRod_C", "Recipe_Alternate_AutomatedMiner_C", 4 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Motor_C", "Recipe_Alternate_AutomatedMiner_C", 1 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_SteelPipe_C", "Recipe_Alternate_AutomatedMiner_C", 4 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_CrystalOscillator_C", "Recipe_Alternate_Beacon_1_C", 1 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_SteelPipe_C", "Recipe_Alternate_Beacon_1_C", 16 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_SteelPlate_C", "Recipe_Alternate_Beacon_1_C", 4 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_IronPlateReinforced_C", "Recipe_Alternate_BoltedFrame_C", 3 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_IronScrew_C", "Recipe_Alternate_BoltedFrame_C", 56 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Rubber_C", "Recipe_Alternate_Cable_1_C", 6 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Wire_C", "Recipe_Alternate_Cable_1_C", 9 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_HighSpeedWire_C", "Recipe_Alternate_Cable_2_C", 3 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Rubber_C", "Recipe_Alternate_Cable_2_C", 2 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_CopperSheet_C", "Recipe_Alternate_CircuitBoard_1_C", 11 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Silica_C", "Recipe_Alternate_CircuitBoard_1_C", 11 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_HighSpeedWire_C", "Recipe_Alternate_CircuitBoard_2_C", 30 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Plastic_C", "Recipe_Alternate_CircuitBoard_2_C", 10 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_AluminumPlate_C", "Recipe_Alternate_ClassicBattery_C", 7 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Plastic_C", "Recipe_Alternate_ClassicBattery_C", 8 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Sulfur_C", "Recipe_Alternate_ClassicBattery_C", 6 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Wire_C", "Recipe_Alternate_ClassicBattery_C", 12 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Wood_C", "Recipe_Alternate_Coal_1_C", 1 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_GenericBiomass_C", "Recipe_Alternate_Coal_2_C", 5 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_HeavyOilResidue_C", "Recipe_Alternate_CoatedCable_C", 2000 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Wire_C", "Recipe_Alternate_CoatedCable_C", 5 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_CopperSheet_C", "Recipe_Alternate_CoatedIronCanister_C", 1 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_IronPlate_C", "Recipe_Alternate_CoatedIronCanister_C", 2 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_IronIngot_C", "Recipe_Alternate_CoatedIronPlate_C", 10 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Plastic_C", "Recipe_Alternate_CoatedIronPlate_C", 2 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_OreIron_C", "Recipe_Alternate_CokeSteelIngot_C", 15 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_PetroleumCoke_C", "Recipe_Alternate_CokeSteelIngot_C", 15 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_CircuitBoard_C", "Recipe_Alternate_Computer_1_C", 7 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_HighSpeedWire_C", "Recipe_Alternate_Computer_1_C", 28 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Rubber_C", "Recipe_Alternate_Computer_1_C", 12 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_CircuitBoard_C", "Recipe_Alternate_Computer_2_C", 8 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_CrystalOscillator_C", "Recipe_Alternate_Computer_2_C", 3 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Silica_C", "Recipe_Alternate_Concrete_C", 3 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Stone_C", "Recipe_Alternate_Concrete_C", 12 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_AluminumPlateReinforced_C", "Recipe_Alternate_CoolingDevice_C", 5 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Motor_C", "Recipe_Alternate_CoolingDevice_C", 1 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_NitrogenGas_C", "Recipe_Alternate_CoolingDevice_C", 24000 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_OreCopper_C", "Recipe_Alternate_CopperAlloyIngot_C", 10 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_OreIron_C", "Recipe_Alternate_CopperAlloyIngot_C", 5 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_CopperSheet_C", "Recipe_Alternate_CopperRotor_C", 6 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_IronScrew_C", "Recipe_Alternate_CopperRotor_C", 52 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_CircuitBoardHighSpeed_C", "Recipe_Alternate_CrystalOscillator_C", 1 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_QuartzCrystal_C", "Recipe_Alternate_CrystalOscillator_C", 10 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Rubber_C", "Recipe_Alternate_CrystalOscillator_C", 7 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_HeavyOilResidue_C", "Recipe_Alternate_DilutedFuel_C", 5000 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Water_C", "Recipe_Alternate_DilutedFuel_C", 10000 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_HeavyOilResidue_C", "Recipe_Alternate_DilutedPackagedFuel_C", 1000 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_PackagedWater_C", "Recipe_Alternate_DilutedPackagedFuel_C", 2 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_ElectromagneticControlRod_C", "Recipe_Alternate_ElectricMotor_C", 1 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Rotor_C", "Recipe_Alternate_ElectricMotor_C", 2 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_AluminaSolution_C", "Recipe_Alternate_ElectroAluminumScrap_C", 12000 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_PetroleumCoke_C", "Recipe_Alternate_ElectroAluminumScrap_C", 4 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_PetroleumCoke_C", "Recipe_Alternate_ElectrodeCircuitBoard_C", 9 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Rubber_C", "Recipe_Alternate_ElectrodeCircuitBoard_C", 6 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_HighSpeedConnector_C", "Recipe_Alternate_ElectromagneticControlRod_1_C", 1 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Stator_C", "Recipe_Alternate_ElectromagneticControlRod_1_C", 2 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Cement_C", "Recipe_Alternate_EncasedIndustrialBeam_C", 5 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_SteelPipe_C", "Recipe_Alternate_EncasedIndustrialBeam_C", 7 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Coal_C", "Recipe_Alternate_EnrichedCoal_C", 5 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Sulfur_C", "Recipe_Alternate_EnrichedCoal_C", 5 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_NitricAcid_C", "Recipe_Alternate_FertileUranium_C", 3000 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_NuclearWaste_C", "Recipe_Alternate_FertileUranium_C", 5 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_OreUranium_C", "Recipe_Alternate_FertileUranium_C", 5 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_SulfuricAcid_C", "Recipe_Alternate_FertileUranium_C", 5000 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_ModularFrame_C", "Recipe_Alternate_FlexibleFramework_C", 1 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Rubber_C", "Recipe_Alternate_FlexibleFramework_C", 8 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_SteelPlate_C", "Recipe_Alternate_FlexibleFramework_C", 6 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_CopperIngot_C", "Recipe_Alternate_FusedWire_C", 4 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_GoldIngot_C", "Recipe_Alternate_FusedWire_C", 1 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_CompactedCoal_C", "Recipe_Alternate_Gunpowder_1_C", 1 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Sulfur_C", "Recipe_Alternate_Gunpowder_1_C", 2 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_AluminumIngot_C", "Recipe_Alternate_HeatFusedFrame_C", 50 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_LiquidFuel_C", "Recipe_Alternate_HeatFusedFrame_C", 10000 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_ModularFrameHeavy_C", "Recipe_Alternate_HeatFusedFrame_C", 1 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_NitricAcid_C", "Recipe_Alternate_HeatFusedFrame_C", 8000 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_AluminumCasing_C", "Recipe_Alternate_HeatSink_1_C", 3 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Rubber_C", "Recipe_Alternate_HeatSink_1_C", 3 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_IronScrew_C", "Recipe_Alternate_HeavyFlexibleFrame_C", 104 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_ModularFrame_C", "Recipe_Alternate_HeavyFlexibleFrame_C", 5 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Rubber_C", "Recipe_Alternate_HeavyFlexibleFrame_C", 20 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_SteelPlateReinforced_C", "Recipe_Alternate_HeavyFlexibleFrame_C", 3 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_LiquidOil_C", "Recipe_Alternate_HeavyOilResidue_C", 3000 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_CircuitBoard_C", "Recipe_Alternate_HighSpeedConnector_C", 2 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_HighSpeedWire_C", "Recipe_Alternate_HighSpeedConnector_C", 60 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Silica_C", "Recipe_Alternate_HighSpeedConnector_C", 25 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_HighSpeedConnector_C", "Recipe_Alternate_HighSpeedWiring_C", 1 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Stator_C", "Recipe_Alternate_HighSpeedWiring_C", 2 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Wire_C", "Recipe_Alternate_HighSpeedWiring_C", 40 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_OreCopper_C", "Recipe_Alternate_IngotIron_C", 2 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_OreIron_C", "Recipe_Alternate_IngotIron_C", 2 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Coal_C", "Recipe_Alternate_IngotSteel_1_C", 2 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_IronIngot_C", "Recipe_Alternate_IngotSteel_1_C", 2 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_CompactedCoal_C", "Recipe_Alternate_IngotSteel_2_C", 3 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_OreIron_C", "Recipe_Alternate_IngotSteel_2_C", 6 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Coal_C", "Recipe_Alternate_InstantScrap_C", 10 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_OreBauxite_C", "Recipe_Alternate_InstantScrap_C", 15 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_SulfuricAcid_C", "Recipe_Alternate_InstantScrap_C", 5000 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Water_C", "Recipe_Alternate_InstantScrap_C", 6000 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_IronPlateReinforced_C", "Recipe_Alternate_ModularFrame_C", 2 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_SteelPipe_C", "Recipe_Alternate_ModularFrame_C", 10 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Cement_C", "Recipe_Alternate_ModularFrameHeavy_C", 22 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_ModularFrame_C", "Recipe_Alternate_ModularFrameHeavy_C", 8 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_SteelPipe_C", "Recipe_Alternate_ModularFrameHeavy_C", 36 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_SteelPlateReinforced_C", "Recipe_Alternate_ModularFrameHeavy_C", 10 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_CrystalOscillator_C", "Recipe_Alternate_Motor_1_C", 1 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Rotor_C", "Recipe_Alternate_Motor_1_C", 3 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Stator_C", "Recipe_Alternate_Motor_1_C", 3 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_CrystalOscillator_C", "Recipe_Alternate_Nobelisk_1_C", 1 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Gunpowder_C", "Recipe_Alternate_Nobelisk_1_C", 8 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_SteelPipe_C", "Recipe_Alternate_Nobelisk_1_C", 8 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "BP_EquipmentDescriptorBeacon_C", "Recipe_Alternate_NuclearFuelRod_1_C", 6 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_CrystalOscillator_C", "Recipe_Alternate_NuclearFuelRod_1_C", 3 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_ElectromagneticControlRod_C", "Recipe_Alternate_NuclearFuelRod_1_C", 10 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_UraniumCell_C", "Recipe_Alternate_NuclearFuelRod_1_C", 100 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_CoolingSystem_C", "Recipe_Alternate_OCSupercomputer_C", 3 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_ModularFrameLightweight_C", "Recipe_Alternate_OCSupercomputer_C", 3 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_LiquidFuel_C", "Recipe_Alternate_Plastic_1_C", 6000 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Rubber_C", "Recipe_Alternate_Plastic_1_C", 6 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_IronPlateReinforced_C", "Recipe_Alternate_PlasticSmartPlating_C", 1 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Plastic_C", "Recipe_Alternate_PlasticSmartPlating_C", 3 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Rotor_C", "Recipe_Alternate_PlasticSmartPlating_C", 1 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_PlutoniumCell_C", "Recipe_Alternate_PlutoniumFuelUnit_C", 20 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_PressureConversionCube_C", "Recipe_Alternate_PlutoniumFuelUnit_C", 1 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_PolymerResin_C", "Recipe_Alternate_PolyesterFabric_C", 16 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Water_C", "Recipe_Alternate_PolyesterFabric_C", 10000 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_LiquidOil_C", "Recipe_Alternate_PolymerResin_C", 6000 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_OreGold_C", "Recipe_Alternate_PureCateriumIngot_C", 2 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Water_C", "Recipe_Alternate_PureCateriumIngot_C", 2000 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_OreCopper_C", "Recipe_Alternate_PureCopperIngot_C", 6 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Water_C", "Recipe_Alternate_PureCopperIngot_C", 4000 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_OreIron_C", "Recipe_Alternate_PureIronIngot_C", 7 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Water_C", "Recipe_Alternate_PureIronIngot_C", 4000 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_RawQuartz_C", "Recipe_Alternate_PureQuartzCrystal_C", 9 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Water_C", "Recipe_Alternate_PureQuartzCrystal_C", 5000 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_CopperIngot_C", "Recipe_Alternate_Quickwire_C", 5 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_GoldIngot_C", "Recipe_Alternate_Quickwire_C", 1 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_AluminumCasing_C", "Recipe_Alternate_RadioControlSystem_C", 60 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_CircuitBoard_C", "Recipe_Alternate_RadioControlSystem_C", 10 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_CrystalOscillator_C", "Recipe_Alternate_RadioControlSystem_C", 1 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Rubber_C", "Recipe_Alternate_RadioControlSystem_C", 30 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_AluminumPlateReinforced_C", "Recipe_Alternate_RadioControlUnit_1_C", 4 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_HighSpeedConnector_C", "Recipe_Alternate_RadioControlUnit_1_C", 2 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_QuartzCrystal_C", "Recipe_Alternate_RadioControlUnit_1_C", 12 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_LiquidFuel_C", "Recipe_Alternate_RecycledRubber_C", 6000 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Plastic_C", "Recipe_Alternate_RecycledRubber_C", 6 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_IronPlate_C", "Recipe_Alternate_ReinforcedIronPlate_1_C", 18 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_IronScrew_C", "Recipe_Alternate_ReinforcedIronPlate_1_C", 50 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_IronPlate_C", "Recipe_Alternate_ReinforcedIronPlate_2_C", 10 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Wire_C", "Recipe_Alternate_ReinforcedIronPlate_2_C", 20 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_SteelPipe_C", "Recipe_Alternate_Rotor_C", 2 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Wire_C", "Recipe_Alternate_Rotor_C", 6 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Rubber_C", "Recipe_Alternate_RubberConcrete_C", 2 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Stone_C", "Recipe_Alternate_RubberConcrete_C", 10 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_SteelPlate_C", "Recipe_Alternate_Screw_2_C", 1 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_IronIngot_C", "Recipe_Alternate_Screw_C", 5 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_RawQuartz_C", "Recipe_Alternate_Silica_C", 3 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Stone_C", "Recipe_Alternate_Silica_C", 5 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_OreBauxite_C", "Recipe_Alternate_SloppyAlumina_C", 10 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Water_C", "Recipe_Alternate_SloppyAlumina_C", 10000 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_HighSpeedWire_C", "Recipe_Alternate_Stator_C", 15 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_SteelPipe_C", "Recipe_Alternate_Stator_C", 4 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_CopperIngot_C", "Recipe_Alternate_SteamedCopperSheet_C", 3 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Water_C", "Recipe_Alternate_SteamedCopperSheet_C", 3000 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_SteelIngot_C", "Recipe_Alternate_SteelCanister_C", 3 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Plastic_C", "Recipe_Alternate_SteelCoatedPlate_C", 2 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_SteelIngot_C", "Recipe_Alternate_SteelCoatedPlate_C", 3 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_SteelIngot_C", "Recipe_Alternate_SteelRod_C", 1 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Battery_C", "Recipe_Alternate_SuperStateComputer_C", 20 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Computer_C", "Recipe_Alternate_SuperStateComputer_C", 3 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_ElectromagneticControlRod_C", "Recipe_Alternate_SuperStateComputer_C", 2 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Wire_C", "Recipe_Alternate_SuperStateComputer_C", 45 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_HeavyOilResidue_C", "Recipe_Alternate_TurboBlendFuel_C", 4000 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_LiquidFuel_C", "Recipe_Alternate_TurboBlendFuel_C", 2000 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_PetroleumCoke_C", "Recipe_Alternate_TurboBlendFuel_C", 3 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Sulfur_C", "Recipe_Alternate_TurboBlendFuel_C", 3 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_CompactedCoal_C", "Recipe_Alternate_Turbofuel_C", 4 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_LiquidFuel_C", "Recipe_Alternate_Turbofuel_C", 6000 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_CompactedCoal_C", "Recipe_Alternate_TurboHeavyFuel_C", 4 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_HeavyOilResidue_C", "Recipe_Alternate_TurboHeavyFuel_C", 5000 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_ElectromagneticControlRod_C", "Recipe_Alternate_TurboMotor_1_C", 5 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_ModularFrameLightweight_C", "Recipe_Alternate_TurboMotor_1_C", 9 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Motor_C", "Recipe_Alternate_TurboMotor_1_C", 7 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Rotor_C", "Recipe_Alternate_TurboMotor_1_C", 7 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Motor_C", "Recipe_Alternate_TurboPressureMotor_C", 4 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_PackagedNitrogenGas_C", "Recipe_Alternate_TurboPressureMotor_C", 24 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_PressureConversionCube_C", "Recipe_Alternate_TurboPressureMotor_C", 1 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Stator_C", "Recipe_Alternate_TurboPressureMotor_C", 8 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_HighSpeedWire_C", "Recipe_Alternate_UraniumCell_1_C", 15 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_OreUranium_C", "Recipe_Alternate_UraniumCell_1_C", 5 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Silica_C", "Recipe_Alternate_UraniumCell_1_C", 3 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Sulfur_C", "Recipe_Alternate_UraniumCell_1_C", 5 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Stone_C", "Recipe_Alternate_WetConcrete_C", 6 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Water_C", "Recipe_Alternate_WetConcrete_C", 5000 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_IronIngot_C", "Recipe_Alternate_Wire_1_C", 5 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_GoldIngot_C", "Recipe_Alternate_Wire_2_C", 1 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_OreBauxite_C", "Recipe_AluminaSolution_C", 12 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Water_C", "Recipe_AluminaSolution_C", 18000 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_AluminumIngot_C", "Recipe_AluminumCasing_C", 3 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_AluminaSolution_C", "Recipe_AluminumScrap_C", 4000 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Coal_C", "Recipe_AluminumScrap_C", 2 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_AluminumIngot_C", "Recipe_AluminumSheet_C", 3 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_CopperIngot_C", "Recipe_AluminumSheet_C", 1 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_AluminaSolution_C", "Recipe_Battery_C", 2000 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_AluminumCasing_C", "Recipe_Battery_C", 1 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_SulfuricAcid_C", "Recipe_Battery_C", 2500 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Cable_C", "Recipe_Beacon_C", 2 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_IronPlate_C", "Recipe_Beacon_C", 3 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_IronRod_C", "Recipe_Beacon_C", 1 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Wire_C", "Recipe_Beacon_C", 15 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_GenericBiomass_C", "Recipe_Biofuel_C", 8 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_HogParts_C", "Recipe_Biomass_AlienCarapace_C", 1 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_SpitterParts_C", "Recipe_Biomass_AlienOrgans_C", 1 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Leaves_C", "Recipe_Biomass_Leaves_C", 10 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Mycelia_C", "Recipe_Biomass_Mycelia_C", 10 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Wood_C", "Recipe_Biomass_Wood_C", 4 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Wire_C", "Recipe_Cable_C", 2 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Gift_C", "Recipe_CandyCane_C", 3 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "BP_EquipmentDescriptorBeacon_C", "Recipe_Cartridge_C", 1 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Gunpowder_C", "Recipe_Cartridge_C", 10 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Rubber_C", "Recipe_Cartridge_C", 10 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_SteelPipe_C", "Recipe_Cartridge_C", 10 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_CopperSheet_C", "Recipe_CircuitBoard_C", 2 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Plastic_C", "Recipe_CircuitBoard_C", 4 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_FlowerPetals_C", "Recipe_ColorCartridge_C", 5 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Cable_C", "Recipe_Computer_C", 9 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_CircuitBoard_C", "Recipe_Computer_C", 10 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_IronScrew_C", "Recipe_Computer_C", 52 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Plastic_C", "Recipe_Computer_C", 18 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_CircuitBoardHighSpeed_C", "Recipe_ComputerSuper_C", 2 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Computer_C", "Recipe_ComputerSuper_C", 2 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_HighSpeedConnector_C", "Recipe_ComputerSuper_C", 3 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Plastic_C", "Recipe_ComputerSuper_C", 28 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Stone_C", "Recipe_Concrete_C", 3 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_AluminumPlateReinforced_C", "Recipe_CoolingSystem_C", 2 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_NitrogenGas_C", "Recipe_CoolingSystem_C", 25000 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Rubber_C", "Recipe_CoolingSystem_C", 2 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Water_C", "Recipe_CoolingSystem_C", 5000 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_CopperIngot_C", "Recipe_CopperDust_C", 30 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_CopperIngot_C", "Recipe_CopperSheet_C", 2 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Cable_C", "Recipe_CrystalOscillator_C", 28 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_IronPlateReinforced_C", "Recipe_CrystalOscillator_C", 5 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_QuartzCrystal_C", "Recipe_CrystalOscillator_C", 36 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_CircuitBoardHighSpeed_C", "Recipe_ElectromagneticControlRod_C", 2 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Stator_C", "Recipe_ElectromagneticControlRod_C", 3 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Cement_C", "Recipe_EncasedIndustrialBeam_C", 5 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_SteelPlate_C", "Recipe_EncasedIndustrialBeam_C", 4 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_GenericBiomass_C", "Recipe_Fabric_C", 5 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Mycelia_C", "Recipe_Fabric_C", 1 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Coal_C", "Recipe_FilterGasMask_C", 5 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Fabric_C", "Recipe_FilterGasMask_C", 2 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Rubber_C", "Recipe_FilterGasMask_C", 2 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_AluminumCasing_C", "Recipe_FilterHazmat_C", 1 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Filter_C", "Recipe_FilterHazmat_C", 1 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_HighSpeedWire_C", "Recipe_FilterHazmat_C", 8 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_CandyCane_C", "Recipe_Fireworks_01_C", 3 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_XmasBranch_C", "Recipe_Fireworks_01_C", 6 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_XmasBow_C", "Recipe_Fireworks_02_C", 3 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_XmasBranch_C", "Recipe_Fireworks_02_C", 4 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Snow_C", "Recipe_Fireworks_03_C", 2 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_XmasBranch_C", "Recipe_Fireworks_03_C", 3 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Plastic_C", "Recipe_FluidCanister_C", 2 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_FluidCanister_C", "Recipe_Fuel_C", 2 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_LiquidFuel_C", "Recipe_Fuel_C", 2000 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_AluminumCasing_C", "Recipe_FusedModularFrame_C", 50 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_ModularFrameHeavy_C", "Recipe_FusedModularFrame_C", 1 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_NitrogenGas_C", "Recipe_FusedModularFrame_C", 25000 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_AluminumIngot_C", "Recipe_GasTank_C", 1 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Coal_C", "Recipe_Gunpowder_C", 1 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Sulfur_C", "Recipe_Gunpowder_C", 2 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_AluminumPlate_C", "Recipe_HeatSink_C", 5 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_CopperSheet_C", "Recipe_HeatSink_C", 3 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Cable_C", "Recipe_HighSpeedConnector_C", 10 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_CircuitBoard_C", "Recipe_HighSpeedConnector_C", 1 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_HighSpeedWire_C", "Recipe_HighSpeedConnector_C", 56 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_AluminumScrap_C", "Recipe_IngotAluminum_C", 6 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Silica_C", "Recipe_IngotAluminum_C", 5 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_OreGold_C", "Recipe_IngotCaterium_C", 3 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_OreCopper_C", "Recipe_IngotCopper_C", 1 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_OreIron_C", "Recipe_IngotIron_C", 1 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Coal_C", "Recipe_IngotSteel_C", 3 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_OreIron_C", "Recipe_IngotSteel_C", 3 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_IronIngot_C", "Recipe_IronPlate_C", 3 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_IronPlate_C", "Recipe_IronPlateReinforced_C", 6 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_IronScrew_C", "Recipe_IronPlateReinforced_C", 12 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_IronIngot_C", "Recipe_IronRod_C", 1 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Biofuel_C", "Recipe_LiquidBiofuel_C", 6 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Water_C", "Recipe_LiquidBiofuel_C", 3000 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_LiquidOil_C", "Recipe_LiquidFuel_C", 6000 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_IronPlateReinforced_C", "Recipe_ModularFrame_C", 3 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_IronRod_C", "Recipe_ModularFrame_C", 12 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_IronScrew_C", "Recipe_ModularFrameHeavy_C", 100 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_ModularFrame_C", "Recipe_ModularFrameHeavy_C", 5 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_SteelPipe_C", "Recipe_ModularFrameHeavy_C", 15 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_SteelPlateReinforced_C", "Recipe_ModularFrameHeavy_C", 5 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Rotor_C", "Recipe_Motor_C", 2 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Stator_C", "Recipe_Motor_C", 2 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_CoolingSystem_C", "Recipe_MotorTurbo_C", 4 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_ModularFrameLightweight_C", "Recipe_MotorTurbo_C", 2 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Motor_C", "Recipe_MotorTurbo_C", 4 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Rubber_C", "Recipe_MotorTurbo_C", 24 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_IronPlate_C", "Recipe_NitricAcid_C", 1 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_NitrogenGas_C", "Recipe_NitricAcid_C", 12000 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Water_C", "Recipe_NitricAcid_C", 3000 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Gunpowder_C", "Recipe_Nobelisk_C", 5 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_SteelPipe_C", "Recipe_Nobelisk_C", 10 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_NitricAcid_C", "Recipe_NonFissileUranium_C", 6000 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_NuclearWaste_C", "Recipe_NonFissileUranium_C", 15 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Silica_C", "Recipe_NonFissileUranium_C", 10 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_SulfuricAcid_C", "Recipe_NonFissileUranium_C", 6000 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_ElectromagneticControlRod_C", "Recipe_NuclearFuelRod_C", 5 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_SteelPlateReinforced_C", "Recipe_NuclearFuelRod_C", 3 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_UraniumCell_C", "Recipe_NuclearFuelRod_C", 50 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_AluminaSolution_C", "Recipe_PackagedAlumina_C", 2000 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_FluidCanister_C", "Recipe_PackagedAlumina_C", 2 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_FluidCanister_C", "Recipe_PackagedBiofuel_C", 2 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_LiquidBiofuel_C", "Recipe_PackagedBiofuel_C", 2000 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_FluidCanister_C", "Recipe_PackagedCrudeOil_C", 2 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_LiquidOil_C", "Recipe_PackagedCrudeOil_C", 2000 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_GasTank_C", "Recipe_PackagedNitricAcid_C", 1 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_NitricAcid_C", "Recipe_PackagedNitricAcid_C", 1000 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_GasTank_C", "Recipe_PackagedNitrogen_C", 1 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_NitrogenGas_C", "Recipe_PackagedNitrogen_C", 4000 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_FluidCanister_C", "Recipe_PackagedOilResidue_C", 2 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_HeavyOilResidue_C", "Recipe_PackagedOilResidue_C", 2000 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_FluidCanister_C", "Recipe_PackagedSulfuricAcid_C", 2 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_SulfuricAcid_C", "Recipe_PackagedSulfuricAcid_C", 2000 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_FluidCanister_C", "Recipe_PackagedTurboFuel_C", 2 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_LiquidTurboFuel_C", "Recipe_PackagedTurboFuel_C", 2000 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_FluidCanister_C", "Recipe_PackagedWater_C", 2 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Water_C", "Recipe_PackagedWater_C", 2000 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_HeavyOilResidue_C", "Recipe_PetroleumCoke_C", 4000 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_LiquidOil_C", "Recipe_Plastic_C", 3000 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Cement_C", "Recipe_PlutoniumCell_C", 4 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_PlutoniumPellet_C", "Recipe_PlutoniumCell_C", 2 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_AluminumPlateReinforced_C", "Recipe_PlutoniumFuelRod_C", 10 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_ElectromagneticControlRod_C", "Recipe_PlutoniumFuelRod_C", 6 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_PlutoniumCell_C", "Recipe_PlutoniumFuelRod_C", 30 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_SteelPlate_C", "Recipe_PlutoniumFuelRod_C", 18 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Crystal_C", "Recipe_PowerCrystalShard_1_C", 1 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_ModularFrameFused_C", "Recipe_PressureConversionCube_C", 1 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_ModularFrameLightweight_C", "Recipe_PressureConversionCube_C", 2 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_AluminumScrap_C", "Recipe_PureAluminumIngot_C", 2 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_RawQuartz_C", "Recipe_QuartzCrystal_C", 5 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_GoldIngot_C", "Recipe_Quickwire_C", 1 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_AluminumCasing_C", "Recipe_RadioControlUnit_C", 32 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Computer_C", "Recipe_RadioControlUnit_C", 1 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_CrystalOscillator_C", "Recipe_RadioControlUnit_C", 1 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_HeavyOilResidue_C", "Recipe_ResidualFuel_C", 6000 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_PolymerResin_C", "Recipe_ResidualPlastic_C", 6 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Water_C", "Recipe_ResidualPlastic_C", 2000 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_PolymerResin_C", "Recipe_ResidualRubber_C", 4 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Water_C", "Recipe_ResidualRubber_C", 4000 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_IronRod_C", "Recipe_Rotor_C", 5 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_IronScrew_C", "Recipe_Rotor_C", 25 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_LiquidOil_C", "Recipe_Rubber_C", 3000 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_IronRod_C", "Recipe_Screw_C", 1 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_RawQuartz_C", "Recipe_Silica_C", 3 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Gift_C", "Recipe_Snow_C", 5 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Snow_C", "Recipe_Snowball_C", 3 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_IronPlateReinforced_C", "Recipe_SpaceElevatorPart_1_C", 1 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Rotor_C", "Recipe_SpaceElevatorPart_1_C", 1 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_ModularFrame_C", "Recipe_SpaceElevatorPart_2_C", 1 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_SteelPlate_C", "Recipe_SpaceElevatorPart_2_C", 12 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Cable_C", "Recipe_SpaceElevatorPart_3_C", 20 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Stator_C", "Recipe_SpaceElevatorPart_3_C", 1 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Motor_C", "Recipe_SpaceElevatorPart_4_C", 2 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Rubber_C", "Recipe_SpaceElevatorPart_4_C", 15 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_CircuitBoard_C", "Recipe_SpaceElevatorPart_5_C", 10 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Computer_C", "Recipe_SpaceElevatorPart_5_C", 2 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_ModularFrameHeavy_C", "Recipe_SpaceElevatorPart_5_C", 2 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Battery_C", "Recipe_SpaceElevatorPart_6_C", 10 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_ElectromagneticControlRod_C", "Recipe_SpaceElevatorPart_6_C", 2 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_ComputerSuper_C", "Recipe_SpaceElevatorPart_7_C", 1 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_CoolingSystem_C", "Recipe_SpaceElevatorPart_8_C", 6 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_ModularFrameFused_C", "Recipe_SpaceElevatorPart_8_C", 2 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_MotorLightweight_C", "Recipe_SpaceElevatorPart_8_C", 2 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_IronRod_C", "Recipe_SpikedRebar_C", 1 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_SteelPipe_C", "Recipe_Stator_C", 3 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Wire_C", "Recipe_Stator_C", 8 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_SteelIngot_C", "Recipe_SteelBeam_C", 4 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_SteelIngot_C", "Recipe_SteelPipe_C", 3 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Sulfur_C", "Recipe_SulfuricAcid_C", 5 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Water_C", "Recipe_SulfuricAcid_C", 5000 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_PackagedAlumina_C", "Recipe_UnpackageAlumina_C", 2 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_PackagedBiofuel_C", "Recipe_UnpackageBioFuel_C", 2 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Fuel_C", "Recipe_UnpackageFuel_C", 2 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_PackagedNitricAcid_C", "Recipe_UnpackageNitricAcid_C", 1 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_PackagedNitrogenGas_C", "Recipe_UnpackageNitrogen_C", 1 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_PackagedOil_C", "Recipe_UnpackageOil_C", 2 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_PackagedOilResidue_C", "Recipe_UnpackageOilResidue_C", 2 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_PackagedSulfuricAcid_C", "Recipe_UnpackageSulfuricAcid_C", 1 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_TurboFuel_C", "Recipe_UnpackageTurboFuel_C", 2 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_PackagedWater_C", "Recipe_UnpackageWater_C", 2 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Cement_C", "Recipe_UraniumCell_C", 3 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_OreUranium_C", "Recipe_UraniumCell_C", 10 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_SulfuricAcid_C", "Recipe_UraniumCell_C", 8000 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_CopperIngot_C", "Recipe_Wire_C", 1 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Gift_C", "Recipe_XmasBall1_C", 1 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Gift_C", "Recipe_XmasBall2_C", 1 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_CopperIngot_C", "Recipe_XmasBall3_C", 2 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_IronIngot_C", "Recipe_XmasBall4_C", 3 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Gift_C", "Recipe_XmasBow_C", 2 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Gift_C", "Recipe_XmasBranch_C", 1 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_CandyCane_C", "Recipe_XmasStar_C", 20 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_XmasWreath_C", "Recipe_XmasStar_C", 5 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_XmasBallCluster_C", "Recipe_XmasWreath_C", 6 });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_XmasBranch_C", "Recipe_XmasWreath_C", 15 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_CircuitBoardHighSpeed_C", "Recipe_AILimiter_C", 1 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_IronPlateReinforced_C", "Recipe_Alternate_AdheredIronPlate_C", 1 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_AluminumCasing_C", "Recipe_Alternate_AlcladCasing_C", 15 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "BP_ItemDescriptorPortableMiner_C", "Recipe_Alternate_AutomatedMiner_C", 1 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "BP_EquipmentDescriptorBeacon_C", "Recipe_Alternate_Beacon_1_C", 20 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_ModularFrame_C", "Recipe_Alternate_BoltedFrame_C", 2 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Cable_C", "Recipe_Alternate_Cable_1_C", 20 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Cable_C", "Recipe_Alternate_Cable_2_C", 11 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_CircuitBoard_C", "Recipe_Alternate_CircuitBoard_1_C", 5 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_CircuitBoard_C", "Recipe_Alternate_CircuitBoard_2_C", 7 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Battery_C", "Recipe_Alternate_ClassicBattery_C", 4 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Coal_C", "Recipe_Alternate_Coal_1_C", 10 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Coal_C", "Recipe_Alternate_Coal_2_C", 6 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Cable_C", "Recipe_Alternate_CoatedCable_C", 9 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_FluidCanister_C", "Recipe_Alternate_CoatedIronCanister_C", 4 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_IronPlate_C", "Recipe_Alternate_CoatedIronPlate_C", 15 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_SteelIngot_C", "Recipe_Alternate_CokeSteelIngot_C", 20 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Computer_C", "Recipe_Alternate_Computer_1_C", 1 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Computer_C", "Recipe_Alternate_Computer_2_C", 3 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Cement_C", "Recipe_Alternate_Concrete_C", 10 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_CoolingSystem_C", "Recipe_Alternate_CoolingDevice_C", 2 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_CopperIngot_C", "Recipe_Alternate_CopperAlloyIngot_C", 20 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Rotor_C", "Recipe_Alternate_CopperRotor_C", 3 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_CrystalOscillator_C", "Recipe_Alternate_CrystalOscillator_C", 1 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_LiquidFuel_C", "Recipe_Alternate_DilutedFuel_C", 10000 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Fuel_C", "Recipe_Alternate_DilutedPackagedFuel_C", 2 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Motor_C", "Recipe_Alternate_ElectricMotor_C", 2 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_AluminumScrap_C", "Recipe_Alternate_ElectroAluminumScrap_C", 20 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Water_C", "Recipe_Alternate_ElectroAluminumScrap_C", 7000 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_CircuitBoard_C", "Recipe_Alternate_ElectrodeCircuitBoard_C", 1 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_ElectromagneticControlRod_C", "Recipe_Alternate_ElectromagneticControlRod_1_C", 2 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_SteelPlateReinforced_C", "Recipe_Alternate_EncasedIndustrialBeam_C", 1 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_CompactedCoal_C", "Recipe_Alternate_EnrichedCoal_C", 5 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Water_C", "Recipe_Alternate_FertileUranium_C", 8000 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Wire_C", "Recipe_Alternate_FusedWire_C", 30 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Gunpowder_C", "Recipe_Alternate_Gunpowder_1_C", 4 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_ModularFrameFused_C", "Recipe_Alternate_HeatFusedFrame_C", 1 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_AluminumPlateReinforced_C", "Recipe_Alternate_HeatSink_1_C", 1 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_ModularFrameHeavy_C", "Recipe_Alternate_HeavyFlexibleFrame_C", 1 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_HeavyOilResidue_C", "Recipe_Alternate_HeavyOilResidue_C", 4000 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_PolymerResin_C", "Recipe_Alternate_HeavyOilResidue_C", 2 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_HighSpeedConnector_C", "Recipe_Alternate_HighSpeedConnector_C", 2 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_IronIngot_C", "Recipe_Alternate_IngotIron_C", 5 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_SteelIngot_C", "Recipe_Alternate_IngotSteel_1_C", 3 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_SteelIngot_C", "Recipe_Alternate_IngotSteel_2_C", 10 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_AluminumScrap_C", "Recipe_Alternate_InstantScrap_C", 30 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Water_C", "Recipe_Alternate_InstantScrap_C", 5000 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_ModularFrame_C", "Recipe_Alternate_ModularFrame_C", 3 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_ModularFrameHeavy_C", "Recipe_Alternate_ModularFrameHeavy_C", 3 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Motor_C", "Recipe_Alternate_Motor_1_C", 6 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_NobeliskExplosive_C", "Recipe_Alternate_Nobelisk_1_C", 4 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_NuclearFuelRod_C", "Recipe_Alternate_NuclearFuelRod_1_C", 3 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_ComputerSuper_C", "Recipe_Alternate_OCSupercomputer_C", 1 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Plastic_C", "Recipe_Alternate_Plastic_1_C", 12 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_PlutoniumFuelRod_C", "Recipe_Alternate_PlutoniumFuelUnit_C", 1 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Fabric_C", "Recipe_Alternate_PolyesterFabric_C", 1 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_HeavyOilResidue_C", "Recipe_Alternate_PolymerResin_C", 2000 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_PolymerResin_C", "Recipe_Alternate_PolymerResin_C", 13 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_GoldIngot_C", "Recipe_Alternate_PureCateriumIngot_C", 1 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_CopperIngot_C", "Recipe_Alternate_PureCopperIngot_C", 15 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_IronIngot_C", "Recipe_Alternate_PureIronIngot_C", 13 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_QuartzCrystal_C", "Recipe_Alternate_PureQuartzCrystal_C", 7 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_HighSpeedWire_C", "Recipe_Alternate_Quickwire_C", 12 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_ModularFrameLightweight_C", "Recipe_Alternate_RadioControlSystem_C", 3 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_ModularFrameLightweight_C", "Recipe_Alternate_RadioControlUnit_1_C", 1 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Rubber_C", "Recipe_Alternate_RecycledRubber_C", 12 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_IronPlateReinforced_C", "Recipe_Alternate_ReinforcedIronPlate_1_C", 3 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_IronPlateReinforced_C", "Recipe_Alternate_ReinforcedIronPlate_2_C", 3 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Rotor_C", "Recipe_Alternate_Rotor_C", 1 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Cement_C", "Recipe_Alternate_RubberConcrete_C", 9 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_IronScrew_C", "Recipe_Alternate_Screw_2_C", 52 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_IronScrew_C", "Recipe_Alternate_Screw_C", 20 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Silica_C", "Recipe_Alternate_Silica_C", 7 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_AluminaSolution_C", "Recipe_Alternate_SloppyAlumina_C", 12000 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Stator_C", "Recipe_Alternate_Stator_C", 2 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_CopperSheet_C", "Recipe_Alternate_SteamedCopperSheet_C", 3 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_FluidCanister_C", "Recipe_Alternate_SteelCanister_C", 2 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_IronPlate_C", "Recipe_Alternate_SteelCoatedPlate_C", 18 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_IronRod_C", "Recipe_Alternate_SteelRod_C", 4 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_ComputerSuper_C", "Recipe_Alternate_SuperStateComputer_C", 2 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_LiquidTurboFuel_C", "Recipe_Alternate_TurboBlendFuel_C", 6000 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_LiquidTurboFuel_C", "Recipe_Alternate_Turbofuel_C", 5000 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_LiquidTurboFuel_C", "Recipe_Alternate_TurboHeavyFuel_C", 4000 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_MotorLightweight_C", "Recipe_Alternate_TurboMotor_1_C", 3 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_MotorLightweight_C", "Recipe_Alternate_TurboPressureMotor_C", 2 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_UraniumCell_C", "Recipe_Alternate_UraniumCell_1_C", 4 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Cement_C", "Recipe_Alternate_WetConcrete_C", 4 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Wire_C", "Recipe_Alternate_Wire_1_C", 9 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Wire_C", "Recipe_Alternate_Wire_2_C", 8 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_AluminaSolution_C", "Recipe_AluminaSolution_C", 12000 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Silica_C", "Recipe_AluminaSolution_C", 5 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_AluminumCasing_C", "Recipe_AluminumCasing_C", 2 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_AluminumScrap_C", "Recipe_AluminumScrap_C", 6 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Water_C", "Recipe_AluminumScrap_C", 2000 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_AluminumPlate_C", "Recipe_AluminumSheet_C", 3 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Battery_C", "Recipe_Battery_C", 1 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Water_C", "Recipe_Battery_C", 1500 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "BP_EquipmentDescriptorBeacon_C", "Recipe_Beacon_C", 1 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Biofuel_C", "Recipe_Biofuel_C", 4 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_GenericBiomass_C", "Recipe_Biomass_AlienCarapace_C", 100 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_GenericBiomass_C", "Recipe_Biomass_AlienOrgans_C", 200 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_GenericBiomass_C", "Recipe_Biomass_Leaves_C", 5 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_GenericBiomass_C", "Recipe_Biomass_Mycelia_C", 10 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_GenericBiomass_C", "Recipe_Biomass_Wood_C", 20 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Cable_C", "Recipe_Cable_C", 1 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_CandyCane_C", "Recipe_CandyCane_C", 1 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_CartridgeStandard_C", "Recipe_Cartridge_C", 5 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_CircuitBoard_C", "Recipe_CircuitBoard_C", 1 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_ColorCartridge_C", "Recipe_ColorCartridge_C", 10 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Computer_C", "Recipe_Computer_C", 1 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_ComputerSuper_C", "Recipe_ComputerSuper_C", 1 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Cement_C", "Recipe_Concrete_C", 1 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_CoolingSystem_C", "Recipe_CoolingSystem_C", 1 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_CopperDust_C", "Recipe_CopperDust_C", 5 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_CopperSheet_C", "Recipe_CopperSheet_C", 1 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_CrystalOscillator_C", "Recipe_CrystalOscillator_C", 2 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_ElectromagneticControlRod_C", "Recipe_ElectromagneticControlRod_C", 2 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_SteelPlateReinforced_C", "Recipe_EncasedIndustrialBeam_C", 1 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Fabric_C", "Recipe_Fabric_C", 1 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Filter_C", "Recipe_FilterGasMask_C", 1 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_HazmatFilter_C", "Recipe_FilterHazmat_C", 1 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_FluidCanister_C", "Recipe_FluidCanister_C", 4 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Fuel_C", "Recipe_Fuel_C", 2 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_ModularFrameFused_C", "Recipe_FusedModularFrame_C", 1 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_GasTank_C", "Recipe_GasTank_C", 1 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Gunpowder_C", "Recipe_Gunpowder_C", 1 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_AluminumPlateReinforced_C", "Recipe_HeatSink_C", 1 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_HighSpeedConnector_C", "Recipe_HighSpeedConnector_C", 1 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_AluminumIngot_C", "Recipe_IngotAluminum_C", 4 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_GoldIngot_C", "Recipe_IngotCaterium_C", 1 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_CopperIngot_C", "Recipe_IngotCopper_C", 1 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_IronIngot_C", "Recipe_IngotIron_C", 1 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_SteelIngot_C", "Recipe_IngotSteel_C", 3 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_IronPlate_C", "Recipe_IronPlate_C", 2 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_IronPlateReinforced_C", "Recipe_IronPlateReinforced_C", 1 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_IronRod_C", "Recipe_IronRod_C", 1 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_LiquidBiofuel_C", "Recipe_LiquidBiofuel_C", 4000 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_LiquidFuel_C", "Recipe_LiquidFuel_C", 4000 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_PolymerResin_C", "Recipe_LiquidFuel_C", 3 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_ModularFrame_C", "Recipe_ModularFrame_C", 2 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_ModularFrameHeavy_C", "Recipe_ModularFrameHeavy_C", 1 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Motor_C", "Recipe_Motor_C", 1 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_MotorLightweight_C", "Recipe_MotorTurbo_C", 1 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_NitricAcid_C", "Recipe_NitricAcid_C", 3000 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_NobeliskExplosive_C", "Recipe_Nobelisk_C", 1 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Water_C", "Recipe_NonFissileUranium_C", 6000 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_NuclearFuelRod_C", "Recipe_NuclearFuelRod_C", 1 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_PackagedAlumina_C", "Recipe_PackagedAlumina_C", 2 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_PackagedBiofuel_C", "Recipe_PackagedBiofuel_C", 2 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_PackagedOil_C", "Recipe_PackagedCrudeOil_C", 2 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_PackagedNitricAcid_C", "Recipe_PackagedNitricAcid_C", 1 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_PackagedNitrogenGas_C", "Recipe_PackagedNitrogen_C", 1 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_PackagedOilResidue_C", "Recipe_PackagedOilResidue_C", 2 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_PackagedSulfuricAcid_C", "Recipe_PackagedSulfuricAcid_C", 2 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_TurboFuel_C", "Recipe_PackagedTurboFuel_C", 2 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_PackagedWater_C", "Recipe_PackagedWater_C", 2 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_PetroleumCoke_C", "Recipe_PetroleumCoke_C", 12 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_HeavyOilResidue_C", "Recipe_Plastic_C", 1000 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Plastic_C", "Recipe_Plastic_C", 2 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_PlutoniumCell_C", "Recipe_PlutoniumCell_C", 1 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_PlutoniumFuelRod_C", "Recipe_PlutoniumFuelRod_C", 1 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_CrystalShard_C", "Recipe_PowerCrystalShard_1_C", 1 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_CrystalShard_C", "Recipe_PowerCrystalShard_2_C", 2 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_CrystalShard_C", "Recipe_PowerCrystalShard_3_C", 5 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_PressureConversionCube_C", "Recipe_PressureConversionCube_C", 1 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_AluminumIngot_C", "Recipe_PureAluminumIngot_C", 1 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_QuartzCrystal_C", "Recipe_QuartzCrystal_C", 3 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_HighSpeedWire_C", "Recipe_Quickwire_C", 5 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_ModularFrameLightweight_C", "Recipe_RadioControlUnit_C", 2 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_LiquidFuel_C", "Recipe_ResidualFuel_C", 4000 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Plastic_C", "Recipe_ResidualPlastic_C", 2 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Rubber_C", "Recipe_ResidualRubber_C", 2 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Rotor_C", "Recipe_Rotor_C", 1 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_HeavyOilResidue_C", "Recipe_Rubber_C", 2000 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Rubber_C", "Recipe_Rubber_C", 2 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_IronScrew_C", "Recipe_Screw_C", 4 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Silica_C", "Recipe_Silica_C", 5 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Snow_C", "Recipe_Snow_C", 2 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_SnowballProjectile_C", "Recipe_Snowball_C", 1 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_SpikedRebar_C", "Recipe_SpikedRebar_C", 1 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Stator_C", "Recipe_Stator_C", 1 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_SteelPlate_C", "Recipe_SteelBeam_C", 1 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_SteelPipe_C", "Recipe_SteelPipe_C", 2 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_SulfuricAcid_C", "Recipe_SulfuricAcid_C", 5000 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_AluminaSolution_C", "Recipe_UnpackageAlumina_C", 2000 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_FluidCanister_C", "Recipe_UnpackageAlumina_C", 2 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_FluidCanister_C", "Recipe_UnpackageBioFuel_C", 2 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_LiquidBiofuel_C", "Recipe_UnpackageBioFuel_C", 2000 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_FluidCanister_C", "Recipe_UnpackageFuel_C", 2 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_LiquidFuel_C", "Recipe_UnpackageFuel_C", 2000 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_GasTank_C", "Recipe_UnpackageNitricAcid_C", 1 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_NitricAcid_C", "Recipe_UnpackageNitricAcid_C", 1000 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_GasTank_C", "Recipe_UnpackageNitrogen_C", 1 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_NitrogenGas_C", "Recipe_UnpackageNitrogen_C", 4000 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_FluidCanister_C", "Recipe_UnpackageOil_C", 2 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_LiquidOil_C", "Recipe_UnpackageOil_C", 2000 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_FluidCanister_C", "Recipe_UnpackageOilResidue_C", 2 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_HeavyOilResidue_C", "Recipe_UnpackageOilResidue_C", 2000 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_FluidCanister_C", "Recipe_UnpackageSulfuricAcid_C", 1 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_SulfuricAcid_C", "Recipe_UnpackageSulfuricAcid_C", 1000 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_FluidCanister_C", "Recipe_UnpackageTurboFuel_C", 2 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_LiquidTurboFuel_C", "Recipe_UnpackageTurboFuel_C", 2000 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_FluidCanister_C", "Recipe_UnpackageWater_C", 2 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Water_C", "Recipe_UnpackageWater_C", 2000 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_SulfuricAcid_C", "Recipe_UraniumCell_C", 2000 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_UraniumCell_C", "Recipe_UraniumCell_C", 5 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_Wire_C", "Recipe_Wire_C", 2 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_XmasBallCluster_C", "Recipe_XmasBallCluster_C", 1 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_XmasBow_C", "Recipe_XmasBow_C", 1 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_XmasBranch_C", "Recipe_XmasBranch_C", 1 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_XmasStar_C", "Recipe_XmasStar_C", 1 });

            migrationBuilder.InsertData(
                table: "RecipeProducts",
                columns: new[] { "ItemId", "RecipeId", "Amount" },
                values: new object[] { "Desc_XmasWreath_C", "Recipe_XmasWreath_C", 2 });

            migrationBuilder.CreateIndex(
                name: "IX_RecipeIngredients_ItemId",
                table: "RecipeIngredients",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeProducts_ItemId",
                table: "RecipeProducts",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_ProducedInId",
                table: "Recipes",
                column: "ProducedInId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RecipeIngredients");

            migrationBuilder.DropTable(
                name: "RecipeProducts");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Recipes");

            migrationBuilder.DropTable(
                name: "BuildableManufacturers");
        }
    }
}
