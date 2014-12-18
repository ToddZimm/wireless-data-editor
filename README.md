Overview
------------------------------------------------------------------------------------------------------------------------
This ArcGIS Desktop Addin includes a toolbar with two tools and a menu that aid in creating 
and maintaining wireless cell sector and cell site data that Public Safety Answering Points (PSAPs)
need for plotting wireless 9-1-1 call data from E911 systems. The datasets created follow
the NENA 02-010 Version 2.0 GIS Data Model.

**Create Sector command:** Allows the user to add/edit one cell sector at a time by entering information into a form.

**Import Cell Table command:** Allows the user to import a table of cell sector data from a Call Routing Sheet into the featureclasses.

**Menu Items:** 
_Change Default State:_ Allows the user to change the state abbreviation used as the default on the Create Sector form. 
_Change Default County ID:_ Allows the user to change the county FIPS code used as the default on the Create Sector form.

Installation
-----------------------------------------------------------------------------------------------------------------------
Double-click the WirelessDataEditor.esriAddIn file. Click the "Install Add-in" button on the next window.

Map Setup
-----------------------------------------------------------------------------------------------------------------------
1. Start ArcMap and create a new empty map project.

2. The Wireless Data Editor toolbar should be visible. If not, right-click on an empty area of the
   toolbars and turn on the Wireless Data Editor toolbar.

3. A personal geodatabase is included in this distribution that contains the schemea that the tools are looking to use. Add both the Cell_Sectors and Cell_Sites featureclasses to the map from the geodatabase.
    
	* The commands look for a map layer name that contains the string "Cell Sector", "Cell_Sector" or "CellSector"
      and one layer name that contains "Cell Site", "Cell_Site" or "CellSite". You can rename the map layers to
      whatever you wish as long as they contain one of these strings in the name.

    * These layers can be any datasource (ArcSDE, file or personal geodatabase) and any projected spatial reference. 

	* The attributes of these layers must follow the attribute schema of the template geodatabase provided.

4. Any other additional layers can be added to the map for background reference.


Creating Cell Sectors and Sites
---------------------------------------------------------------------------------------------------------
To create a single cell sector polygon and optional site point, click the Create Sector command button. Fill in
all required fields (indicated by an asterix). If "Update Cell Site Point" is checked, the command will also 
create the cell site point that is associated with the sector. Fill in additional information for the site
point. Click the OK button to create the sector and site.

If the cell sector or site point already exist, the command will delete the existing records and create new ones
with the new data.

_NOTE:_ The default State and County FIPS values can be changed using the commands under the Wireless Data Editor menu.


Importing data in a table
--------------------------------------------------------------------------------------------------------------------
The Import Cell Table command allows you to import a batch of sectors from data stored in a spreadsheet or table. The
table to be imported must have the column names as shown in the CellSectors.xlt Excel template in the \Templates 
folder included with this distribution. Field definitions are below.

1. Add the table to be imported to ArcMap.

2. Click the Import Cell Table command.

3. Select the table to be imported from the drop-down list.

4. Select the options to update the Cell Sectors and/or Cell Sites layers as desired.

5. Click OK.


Import Table Field Definitions
----------------------------------------------------------------------------------------------------------------------
LDTProvider - NENA Company ID of the wireless carrier

CellID - Unique cell site ID from the carrier

SectorID - Sector number within the cell site.

Latitude - Latitude of the cell site in decimal degrees.

Longitude - Longitude of the cell site in decimal degrees.

Azimuth - Orientation of the cell sector antenna face in degrees, North being 0 degrees.

BeamWidth - Width of the antenna beam in degrees

Radius - Average sector range radius in miles.

SiteCommonName - Site name assigned by the carrier.

SiteAddress - Street address of the site location.

SiteCommunity - Name of the city or municipality where the site is located.

SiteState - Two-character abbreviation of the state where the site is located.

CountyID - FIPS code of the county where the site is located.

Technology - Type of air interface technology used by the site.

Source - Source of the data

Updated - Date of the last update to the data.

Attribute field definitions taken from NENA standard 02-010 Version 2.0 GIS Data Model.
http://www.nena.org/?page=DataFormats


Update History
----------------------------------------------------------------------------------------------------------------------
12/19/2011 - Version 1.0
  * First release of ArcGIS 10 Addin version

09/05/2012 - Version 1.1
  * Improved error messages in Import Cell Table when table does not match expected schema.
  * Fixed default date formatting

12/18/2014
  * Source code released on GitHub.