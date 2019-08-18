## ItemsControl
```xml

	<UserControl.Resources>
		<DataTemplate x:Key="StyleHere">
			<CheckBox Content="{Binding Name}" IsChecked="{Binding IsIncluded}"/>
		</DataTemplate>

	</UserControl.Resources>
<StackPanel>
    <ItemsControl ItemsSource="{Binding SourceArray}" ItemTemplate="{StaticResource StyleHere}" Margin="15,10,0,0"/>
</StackPanel>
```