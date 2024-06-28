using Blater.Enumerations;

namespace Blater.Attributes.Auto;

[AttributeUsage(AttributeTargets.Class)]
public sealed class AutoPageAttribute(
    bool mainPage,
    bool createPage,
    bool editPage,
    bool detailsPage,
    BlaterProjects project)
    : Attribute
{
    public bool MainPage { get; internal set; } = mainPage;
    public bool EditPage { get; internal set; } = editPage;
    public bool CreatePage { get; internal set; } = createPage;
    public bool DetailsPage { get; internal set; } = detailsPage;
    public BlaterProjects Project { get; } = project;
}