### Putting a link in WPF
```xml
 <Application.Resources>

	    <Style x:Key="ApplicationLinkButtonNoUnderLine" TargetType="{x:Type Button}">
		    <Setter Property="Template">
			    <Setter.Value>
				    <ControlTemplate TargetType="{x:Type Button}">
					    <TextBlock>
						    <ContentPresenter />
					    </TextBlock>
				    </ControlTemplate>
			    </Setter.Value>
		    </Setter>
		    <Setter Property="HorizontalContentAlignment" Value="Center"/>
		    <Setter Property="VerticalContentAlignment" Value="Center"/>
		    <Setter Property="Foreground" Value="LightBlue" />
		    <Setter Property="FontSize" Value="12" />
		    <Setter Property="FontWeight" Value="Bold" />
		    <Setter Property="Margin" Value="15,0,0,0" />

		    <Setter Property="Cursor" Value="Hand" />

		    <Style.Triggers>
			    <Trigger Property="IsMouseOver" Value="true">
				    <Setter Property="Foreground" Value="Red" />
			    </Trigger>
		    </Style.Triggers>
	    </Style>

</Application.Resources>

<Button Content="{Binding address}" Style="{StaticResource ApplicationLinkButtonNoUnderLine}" Command="{Binding BrowseToAddress}"/>
```