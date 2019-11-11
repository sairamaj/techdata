# Command binding to Ctrl Keys

```xml

    <Window.Resources>
        <command:CommandReference x:Key="ExecuteCommandReference" Command="{Binding ExecuteCommand}" />
    </Window.Resources>

    <Window.InputBindings>
        <KeyBinding Key="E" Modifiers="Control" Command="{StaticResource ExecuteCommandReference}" />
    </Window.InputBindings>

```
