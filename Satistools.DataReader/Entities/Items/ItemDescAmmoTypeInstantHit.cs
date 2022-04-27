﻿using System.Drawing;
using System.Text.Json;
using System.Text.Json.Serialization;
using Satistools.DataReader.Attributes;
using Satistools.DataReader.Converters;
using Satistools.DataReader.Converters.Items;

namespace Satistools.DataReader.Entities.Items;

[DataEntity("Class'/Script/FactoryGame.FGItemDescAmmoTypeInstantHit'")]
public class ItemDescAmmoTypeInstantHit : IItemDescriptor
{
    public string ClassName { get; set; } = string.Empty;

    [JsonPropertyName("mDisplayName")]
    public string DisplayName { get; set; } = string.Empty;

    [JsonPropertyName("mDescription")]
    public string Description { get; set; } = string.Empty;

    [JsonPropertyName("mAbbreviatedDisplayName")]
    public string AbbreviatedDisplayName { get; set; } = string.Empty;

    [JsonPropertyName("mStackSize")]
    [JsonConverter(typeof(ItemStackSizeJsonConverter))]
    public ItemStackSize StackSize { get; set; } = ItemStackSize.NotAvailable;

    [JsonPropertyName("mCanBeDiscarded")]
    [JsonConverter(typeof(BooleanJsonConverter))]
    public bool CanBeDiscarded { get; set; }
    
    [JsonPropertyName("mRememberPickUp")]
    [JsonConverter(typeof(BooleanJsonConverter))]
    public bool RememberPickUp { get; set; }
    
    [JsonPropertyName("mEnergyValue")]
    public float EnergyValue { get; set; }
    
    [JsonPropertyName("mRadioactiveDecay")]
    public float RadioactiveDecay { get; set; }

    [JsonPropertyName("mForm")]
    [JsonConverter(typeof(ItemFormJsonConverter))]
    public ItemForm Form { get; set; } = ItemForm.NotAvailable;

    [JsonPropertyName("mSmallIcon")]
    public string SmallIcon { get; set; } = string.Empty;

    [JsonPropertyName("mPersistentBigIcon")]
    public string PersistentBigIcon { get; set; } = string.Empty;

    [JsonPropertyName("mSubCategories")]
    public string SubCategories { get; set; } = string.Empty;
    
    [JsonPropertyName("mMenuPriority")]
    public float MenuPriority { get; set; }

    [JsonPropertyName("mFluidColor")]
    [JsonConverter(typeof(ColorJsonConvertor))]
    public Color FluidColor { get; set; }

    [JsonPropertyName("mGasColor")]
    [JsonConverter(typeof(ColorJsonConvertor))]
    public Color GasColor { get; set; }
    
    [JsonPropertyName("mResourceSinkPoints")]
    public int ResourceSinkPoints { get; set; }
    
    [JsonPropertyName("mBuildMenuPriority")]
    public float BuildMenuPriority { get; set; }
    
    [JsonExtensionData]
    public Dictionary<string, JsonElement> ExtensionData { get; set; } = new();
}