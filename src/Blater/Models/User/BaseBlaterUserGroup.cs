using System.ComponentModel;
using Blater.Models.User.Permissions;
using EnumFastToStringGenerated;

namespace Blater.Models.User;

public abstract class BaseBlaterUserGroup<TUser, TFeature, TPermission> where TUser : BaseBlaterUser where TPermission : notnull where TFeature : notnull
{
    public  abstract string Name { get; set; }
    public abstract List<TUser> Users { get; set; }
    
    public abstract Dictionary<TFeature, List<TPermission>> Permissions { get; set; }
}

/*public class TestUser : BaseBlaterUser
{
    
}

public enum TestFeature
{
    Auth,
    Database,
    ProjetoDaLipor,
    NotaFiscal
}

[EnumGenerator]
public enum TestEnum
{
    [Description("")]
    All,
    Create,
    Read,
    Update,
    Auth,
    Database,
    ProjetoDaLipor,
    NotaFiscal,
    CriarNotaFiscalParaCliente //123
}

public class TestUserGroup : BaseBlaterUserGroup<TestUser, TestFeature, TestEnum>
{
    public override string Name { get; set; }
    
    public override List<TestUser> Users { get; set; } = [];
    
    public override Dictionary<TestFeature, List<TestEnum>> Permissions { get; set; } = new Dictionary<TestFeature, List<TestEnum>>
    {
        {TestFeature.Auth, [TestEnum.All]}, //Auth:All
        {"Database", [TestEnum.Create]}, //Database:Create
        {"ProjetoDaLipor", [TestEnum.Read, TestEnum.Update]}, //ProjetoDaLipor:Read ProjetoDaLipor:Update
        {"NotaFiscal", [TestEnum.CriarNotaFiscalParaCliente]} //NotaFiscal:CriarNotaFiscalParaCliente
    };
}*/