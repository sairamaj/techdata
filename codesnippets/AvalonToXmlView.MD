[AvalonEditBehavior](https://stackoverflow.com/questions/18964176/two-way-binding-to-avalonedit-document-text-using-mvvm)

* Install-Package AvalonEdit
* Install-Package System.Windows.Interactivity.WPF

```xml
 <Window.Resources>
        <Style x:Key="AvalonTextBoxStyles" TargetType="avalonedit:TextEditor">
            <Setter Property="IsReadOnly"  Value="True" />
            <Setter Property="WordWrap"  Value="True" />
            <Setter Property="BorderThickness"  Value="0" />
            <Setter Property="FontSize"  Value="13" />
            <Setter Property="FontFamily"  Value="Consolas" />
            <Setter Property="SyntaxHighlighting"  Value="XML" />
            <Setter Property="ShowLineNumbers"  Value="True" />
            <Setter Property="LineNumbersForeground"  Value="Magenta" />
            <Setter Property="VerticalScrollBarVisibility"  Value="Auto" />
            <Setter Property="HorizontalScrollBarVisibility"  Value="Auto" />
        </Style>
    </Window.Resources>
    <Grid>
        <avalonedit:TextEditor 
                               Style="{StaticResource AvalonTextBoxStyles}">
            <interactivity:Interaction.Behaviors>
                <views:AvalonEditBehaviour GiveMeTheText="{Binding Data, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}"/>
            </interactivity:Interaction.Behaviors>
        </avalonedit:TextEditor>
```