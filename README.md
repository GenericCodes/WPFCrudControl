# WPFCrudControl
A generic WPF CrudControl implemented based on the MVVM pattern. The control abstracts both the UI and business logic to achieve a foundation for a complete CRUD operation implementation (Add, Edit, Delete, Listing with sorting, paging and searching).

<h2>The Result</h2>
![alt text](https://cloud.githubusercontent.com/assets/20560529/20644314/ec3c0a98-b438-11e6-9fad-3d7f4b1747d7.png)

<h3>Xaml usage</h3>

<pre lang="xml">
&lt;crud:GenericCRUDControl&gt;
    &lt;crud:GenericCRUDControl.SortingProperties&gt;
        &lt;crud:SortingProperty DisplayName=&quot;Product Name&quot; PropertyPath=&quot;ProductName&quot;&gt;
        &lt;/crud:SortingProperty&gt;
        &lt;crud:SortingProperty DisplayName=&quot;Category&quot; PropertyPath=&quot;Category.CategoryName&quot;&gt;
        &lt;/crud:SortingProperty&gt;
        &lt;crud:SortingProperty DisplayName=&quot;Supplier&quot; PropertyPath=&quot;Supplier.ContactName&quot;&gt;
        &lt;/crud:SortingProperty&gt;
    &lt;/crud:GenericCRUDControl.SortingProperties&gt;
    &lt;crud:GenericCRUDControl.Columns&gt;
        &lt;crud:CustomDataGridColumn Header=&quot;Category Name&quot; BindingExpression=&quot;Category.CategoryName&quot;&gt;
        &lt;/crud:CustomDataGridColumn&gt;
        &lt;crud:CustomDataGridColumn Header=&quot;Product Name&quot; BindingExpression=&quot;ProductName&quot;&gt;
        &lt;/crud:CustomDataGridColumn&gt;
        &lt;crud:CustomDataGridColumn ColumnType=&quot;TemplateColumn&quot; Header=&quot;Stock&quot;&gt;
            &lt;crud:CustomDataGridColumn.DataGridColumnTemplate&gt;
                &lt;DataTemplate&gt;
                    &lt;ProgressBar Maximum=&quot;150&quot; Value=&quot;{Binding UnitsInStock}&quot;&gt;&lt;/ProgressBar&gt;
                &lt;/DataTemplate&gt;
            &lt;/crud:CustomDataGridColumn.DataGridColumnTemplate&gt;
        &lt;/crud:CustomDataGridColumn&gt;
        &lt;crud:CustomDataGridColumn Header=&quot;Supplier Name&quot; 
         BindingExpression=&quot;Supplier.ContactName&quot; Width=&quot;*&quot;&gt;&lt;/crud:CustomDataGridColumn&gt;
    &lt;/crud:GenericCRUDControl.Columns&gt;
&lt;/crud:GenericCRUDControl&gt;</pre>

<h2>Getting Started</h2>

<h4>Installation using Nuget&nbsp;</h4>

<p><strong>WPF CrudControl</strong> is available on <a href="https://www.nuget.org/packages/WPFCRUDControl" target="_blank">NuGet</a>, you can install it using nuget manager or run the following command in the package manager console.</p>

<pre class="notranslate" id="pre201990" lang="text" style="margin-removed 0px;">
<b>PM&gt; Install-Package WPFCRUDControl</b></pre>
For the getting-started details got to the <a href="https://www.codeproject.com/articles/1118762/generic-wpf-crud-control-getting-started">CodeProject Article</a>
<h2>Solution Design</h2>

![generic crud](https://cloud.githubusercontent.com/assets/20560529/20644254/3665bb8e-b437-11e6-90e9-4ecbb0565e5f.png)
For the solution design details got to the <a href="https://www.codeproject.com/Articles/1042837/Generic-WPF-CRUD-Control-Solution-Design">CodeProject Article</a>
<h2>Northwind Demo</h2>

<p>The solution is applied on <code>Northwind</code> database for two modules <code>Suppliers</code> and <code>Products</code>. In the demo, we used Unity as a IoC/DI container, MVVMLight toolkit and WPF Modern UI library for styling the main window and navigation.</p>

<h4>To run the demo:</h4>

<ul>
	<li>Restore packages using NuGet packages manager</li>
	<li>Install SQL Server <a href="https://www.microsoft.com/en-us/download/details.aspx?id=29062" target="_blank">LocalDB</a></li>
</ul>
