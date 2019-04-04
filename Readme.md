<!-- default file list -->
*Files to look at*:

* [styles1.css](./CS/WebSite/CSS/styles1.css)
* [styles2.css](./CS/WebSite/CSS/styles2.css)
* [CssJsHandler.aspx](./CS/WebSite/CssJsHandler.aspx) (VB: [CssJsHandler.aspx](./VB/WebSite/CssJsHandler.aspx))
* [CssJsHandler.aspx.cs](./CS/WebSite/CssJsHandler.aspx.cs) (VB: [CssJsHandler.aspx.vb](./VB/WebSite/CssJsHandler.aspx.vb))
* [default.aspx](./CS/WebSite/default.aspx) (VB: [default.aspx](./VB/WebSite/default.aspx))
* [default.aspx.cs](./CS/WebSite/default.aspx.cs) (VB: [default.aspx.vb](./VB/WebSite/default.aspx.vb))
* [scripts.js](./CS/WebSite/Scripts/scripts.js) (VB: [scripts.js](./VB/WebSite/Scripts/scripts.js))
<!-- default file list end -->
# How to compress and merge custom CSS and Script files


<p>This example demonstrates how to enable merging and compression of custom CSS and JavaScript files. Files compression is implemented by using the <strong>MakeResponseCompressed</strong> method. </p><p>For merging, you should specify either a folder with custom files, or individual files as a parameter within the <link> and <script> tags. </p><p>In this example, the "CssJsHandler.aspx" prefix within the <script> and <link> tags defines a custom written handler that implements merging and compression of the specified JavaScript and CSS files. Specifying the folder with custom files or individual file for merging, the "CssJsHandler.aspx" prefix should also contain the corresponding attribute - cssfolder, cssfile, jsfolder or jsfile. </p><p>If a folder is specified as a parameter, custom files are initially merged and then compressed. Such merging causes a page to load faster. Linking an individual file is useful for only merging the specified CSS files. </p><p>Note that this example represents a temporary workaround, until suggestion <a href="https://www.devexpress.com/Support/Center/p/S33533">Compression Enhancements - Add an ability to compress and merge custom CSS/Script files</a> is implemented in version 2010 vol.1.</p>

<br/>


