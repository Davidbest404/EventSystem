using deVoid.Utils;
using MyGame.Core.Types;

namespace MyGame.Core.Signals
{
    public class MenuSwitchSignal : ASignal<MenuState> { }
    public class ResourceModifierSignal : ASignal<ResourceType, int, bool> { }
    public class ResourceResetSignal : ASignal { }
    public class ResourceUpdatedSignal : ASignal { }
}