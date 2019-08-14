## Using common styles

### View
```xml

	<Window.Resources>
		<Style x:Key="TextBoxStyles">
			<Setter Property="Control.Width" Value="200"/>
			<Setter Property="Control.Height" Value="20"/>
		</Style>
	</Window.Resources>
```

```xml
<TextBox Text="{Binding TextInput}" HorizontalAlignment="Left" Margin="3,0,0,0" Grid.Row="0" Grid.Column="1" Style="{StaticResource TextBoxStyles}"/>
```