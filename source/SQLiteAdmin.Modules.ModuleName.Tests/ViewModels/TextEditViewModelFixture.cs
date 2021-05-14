using Moq;
using Prism.Events;
using Prism.Regions;
using Xeno.SQLiteAdmin.Modules.TextEditorModule.ViewModels;
using Xeno.SQLiteAdmin.Services.Interfaces;
using Xunit;

namespace Xeno.SQLiteAdmin.Modules.ModuleName.Tests.ViewModels
{
  public class TextEditViewModelFixture
  {
    private const string MessageServiceDefaultMessage = "Some Value";

    private Mock<IDatabaseService> _mockDatabaseService;
    private Mock<IEventAggregator> _mockEvents;
    private Mock<IMessageService> _mockMessageService;
    private Mock<IRegionManager> _mockRegionManager;

    public TextEditViewModelFixture()
    {
      var messageService = new Mock<IMessageService>();
      messageService.Setup(x => x.GetMessage()).Returns(MessageServiceDefaultMessage);
      _mockMessageService = messageService;

      _mockRegionManager = new Mock<IRegionManager>();
      _mockEvents = new Mock<IEventAggregator>();
      _mockDatabaseService = new Mock<IDatabaseService>();
    }

    [Fact]
    public void MessageINotifyPropertyChangedCalled()
    {
      var vm = new TextEditViewModel(_mockRegionManager.Object, _mockMessageService.Object, _mockEvents.Object, _mockDatabaseService.Object);
      Assert.PropertyChanged(vm, nameof(vm.Text), () => vm.Text = "Changed");
    }

    [Fact]
    public void MessagePropertyValueUpdated()
    {
      var vm = new TextEditViewModel(_mockRegionManager.Object, _mockMessageService.Object, _mockEvents.Object, _mockDatabaseService.Object);

      _mockMessageService.Verify(x => x.GetMessage(), Times.Once);

      Assert.Equal(MessageServiceDefaultMessage, vm.Text);
    }
  }
}
