# Define Header style for Expander and not inheriting to child controls

### Expander
```xml

	<UserControl.Resources>
		<Style x:Key="HeaderControlStyle">
			<Setter Property="Control.Foreground" Value="Blue"/>
			<Setter Property="Control.FontWeight" Value="Bold"/>
		</Style>
	</UserControl.Resources>

<Expander Header="Single File" IsExpanded="True" >
			<Expander.HeaderTemplate>
				<DataTemplate>
					<TextBlock Text="Single File" Style="{StaticResource HeaderControlStyle}"/>
				</DataTemplate>
			</Expander.HeaderTemplate>
			<views:SingleFileRunModelView DataContext="{Binding SingleFileRunViewModel}" />
		</Expander>

```

### Tabe
```xml

<TabControl FontSize="18pt">
  <TabItem>
    <TabItem.Header>
        <TextBlock Style="{StaticResource tabHeaderStyle}">Tab 1</TextBlock>
    </TabItem.Header>
    <Button>Button 1</Button>
  </TabItem>
</TabControl>

```
