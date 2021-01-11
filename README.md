![Round Logo](http://www.gridprotectionalliance.org/images/products/icons%2064/PQio.png)![PQio](https://raw.githubusercontent.com/GridProtectionAlliance/PQio/master/src/Documentation/Readme%20files/openSEE%20Logo.png)

openSEPQio is an open source application published under the MIT license that provides a quick means to convert PQDIF files to the simple PQDS.csv format so that waveform data can be easily reviewed, edited if necessary and shared with colleagues.

The PQDS.csv format facilitates the review and inclusion (or exclusion) of meta data about the disturbance waveform to enable this data to be sent to others with the appropriate degree of anonymization and then easily consumed without the need for parsing custom formats like PQDIF or COMTRADE.

For those that have GPA’s openXDA suite of tools, the System Event Browser (SE Browser) can be used to find and export PQ data in PQDS.csv format.  The PQio application can be used to edit this exported waveform data for sharing in cases where this is more convenient that editing the exported data in a spreadsheet application.

# To use PQio

1.	Click on the “File” button to open an individual PQDIF file or the “Folder” button to open all PQDIF files within that folder.
2.	Right-click on an item to edit, add or delete meta data.
3.	Trim the available events for export down to the those that are needed.
4.	Select a channel and then drag an event into one of the two plot panels at the bottom to preview the event waveform.
5.	Export the waveform data by clicking on the “Export to PQDS” button.

# The PQDS.csv format

The Power Quality Data Sharing (PQDS) format is a comma-separated value file that enables the easy review, editing and sharing of electric power disturbance waveforms. It is designed to be a simple and extensible human-to-human data format that complements the standard system-to-system waveform data formats of PQDIF and COMTRADE.

The PQDS format CSV file includes two information sections – (1) a meta-data section with key-value information about the waveform, and (2) a data section with the time-series voltage and current waveform measurements. Each of these two sections individually complies with the RFC 4180 CSV format specification with header data to identify the names of the fields that follow.  
For mormore information, see the [PQDS.csv file specification] (https://gridprotectionalliance.org/pdf/pqdscsv_specification.pdf).
# Contributing
If you would like to contribute please:

1. Read our [styleguide.](https://www.gridprotectionalliance.org/docs/GPA_Coding_Guidelines_2011_03.pdf)
* Fork the repository.
* Work your magic.
* Create a pull request.
