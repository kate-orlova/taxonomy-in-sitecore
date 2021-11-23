![GitHub release (latest by date)](https://img.shields.io/github/v/release/kate-orlova/taxonomy-in-sitecore)
[![GitHub release](https://img.shields.io/github/release-date/kate-orlova/taxonomy-in-sitecore.svg?style=flat)](https://github.com/kate-orlova/taxonomy-in-sitecore/releases/tag/v2.1)
[![GitHub license](https://img.shields.io/github/license/kate-orlova/taxonomy-in-sitecore.svg)](https://github.com/kate-orlova/taxonomy-in-sitecore/blob/master/LICENSE)
![GitHub language count](https://img.shields.io/github/languages/count/kate-orlova/taxonomy-in-sitecore.svg?style=flat)
![GitHub top language](https://img.shields.io/github/languages/top/kate-orlova/taxonomy-in-sitecore.svg?style=flat)
![GitHub repo size](https://img.shields.io/github/repo-size/kate-orlova/taxonomy-in-sitecore.svg?style=flat)
![GitHub contributors](https://img.shields.io/github/contributors/kate-orlova/taxonomy-in-sitecore)
![GitHub commit activity](https://img.shields.io/github/commit-activity/y/kate-orlova/taxonomy-in-sitecore)

# Taxonomy in Sitecore
Taxonomy in Sitecore module aims to support your marketing strategy and provide a consistent way of organising your content in Sitecore. Version 2.1 is compatible with [Sitecore 10.2](https://dev.sitecore.net/Downloads/Sitecore_Experience_Platform/102/Sitecore_Experience_Platform_102.aspx).

Once the taxonomy tags are defined, you can easily classify your Sitecore Content Items by assigning the appropriate tags and start creating personalisation rules based on them. This will empower you to serve the relevant content for the target audience(s) while using Sitecore Experience Analytics to measure traffic, engagement value and outcomes.

As soon as this is all setup, you can get more insights on how visitors are interacting with your website and its content. This is very important for your marketing strategy as you continue to learn and adjust this over time in accordance with the continual cycle: _test, learn, adjust and re-test_. 

## Taxonomy Definition
The module ships the following **Taxonomy** defined around the programming languages and their types & classifications:

- Programming Language
     - Programming Language Type
     - Programming Classification

A base Content template has a _"Programming Language" Multilist with Search_ field to assign the relevant **Taxonomy** tags.
![Taxonomy Field](/assets/taxonomy%20field.png)

## Flexible Settings
Taxonomy field name can be specified in a config file. There is a _TaxonomyField_ setting in `..\src\Foundation\TaxonomyInSitecore\App_Config\Include\TaxonomyInSitecore.config`, so that you can easily reference to your custom taxonomy field.


## Taxonomy Profiles
Continuing the programming topic, **Sitecore Profiles**, presented in the module, are aligned with the Programming Classifications and implemented on the example of the next IT Professionals:
- Back-End Developer
- Front-End developer
- Full Stack Developer

Then the predefined **Profile Cards** are being associated to programming language **Tags**. ![Tag Profile Card](/assets/tag%20profile%20card.png)

### Pipelines
_ProcessTaxonomyProfiles_ custom pipeline hooks into `Sitecore.Analytics.Pipelines.ProcessItem.ProcessItemProcessor` pipeline to dynamically assign the relevant Profile Cards to the context item based on the linked tags to it.

Note, that there is no need to create a physical linkage between your Content Items and Profiles Cards as you can associate the required Profile Cards to Content Items and score the latter during the _ProcessItemProcessor_ pipeline execution.

### Ease of Management
The genius of this approach is that you no longer need to assign the required Profile Cards to each Content Item individually. Instead, you just need to link them to your **Taxonomy** tags and then they will be inherited automatically via tags. As a result it will save you from the duplication of work and bring more efficiency to your content classification.

### Taxonomy Components
**Tags** _View Rendering_ `..\src\Feature\TaxonomyComponents\Views\Taxonomy\Tags.cshtml` and **TagList** _Controller Rendering_ `..\src\Feature\TaxonomyComponents\Views\Taxonomy\TagList.cshtml` list all tags assigned to an Item. Depending on your specific project requirements you can use either one.

## Sitecore Packages
Sitecore packages contain:

1. **Data Templates**
   - Programming Classification
   - Programming Language
   - Programming Language Type
![Data Templates](/assets/data%20templates.png)
2. **Tags**
   - Programming Classifications
   - Programming Language Types
   - Programming Languages
![Tags](/assets/tags.png)
3. **Profiles**
![Profiles](/assets/profiles.png)
   - Profile Keys
   - Profile Cards
![Back-end Profile Card](/assets/back-end%20profile%20card.png)
   - Pattern Cards
![Back-end Pattern Card](/assets/back-end%20pattern%20card.png)
4. **Views**
5. **Dimension**
![Taxonomy dimension](/assets/taxonomy%20dimension.png)
6. **Event**
7. **Reports**

## SQL Package
SQL package (`../SQL scripts/`) contains the following script to support the taxonomy custom metric; when executing, follow the order they are listed below to make sure that the required SQL entities are present:
1. `Fact_TaxonomyMetrics.sql` - creates a custom table in SQL;
2. `TaxonomyMetrics_Type.sql` - creates a type to manipulate the data in the custom table;
3. `Add_TaxonomyMetrics_Tvp.sql` - creates a stored procedure.

# Reporting
**TaxonomyReporting** project implements a custom Taxonomy report to review the overall tags performance and drill down to the individual tags - see the total number of visits and engagement value:

_Taxonomy report for top tags_
![Taxonomy report for top tags](/assets/taxonomy%20report%20for%20top%20tags.jpg)

_Individual tag performance_
![Individual tag performance](/assets/taxonomy%20tag%20performance.jpg)

The implementation of the custom report consists of the below classes:
 - `..\Models\TaxonomyMetrics.cs` defines a model for the taxonomy dimension and metrics;

 - `..\Aggregation\TagFactCalculator.cs` calculates the values of individual metrics defined in the `TaxonomyMetrics` model, for example, number of visits and engagement value;

 - `..\Aggregation\TaxonomyResolver.cs` extends the `IGroupResolver<T>` interface to determine tags associated with a visit and group records for dimension while implementing the `MeasureGroupOccurrences()` method;

 - `..\Pipelines\RegisterTaxonomyPageEvent.cs` registers an event with tags associated with a visited page and store it in xDB.

# How to Install
1. Include the _TaxonomyInSitecore_ project to your Visual Studio solution;
1. Define your **Taxonomy** structure;
1. Create _Data Templates_ relevant to your **Taxonomy** structure in your Sitecore instance on the example of the attached ones in the `Taxonomy Data Templates-1.0.zip` package;
1. Populate your **Taxonomy** with the relevant tags;
1. Create _Profiles_ and assign them to tags accordingly;
1. Add a _Taxonomy field_ to your content _Data Templates_ and configure the _ProcessTaxonomyProfiles_ custom pipeline by adding your _Taxonomy field_ reference to `..\TaxonomyInSitecore\App_Config\Include\TaxonomyInSitecore.config`. Make sure that the config file is deployed to your Sitecore destination folder;
1. Assign the relevant tags to your content items. Adapt _Renderings_ from the enclosed `Taxonomy Views-1.1.zip` package where applicable to render the relevant tags in the front-end for the _Context Item_.
1. Execute SQL-scripts from the SQL package (`../SQL scripts/`) for the **Reporting** DB; note that the executiuon order is important and please follow the order the scripts are listed above to make sure that the required table and type is created before calling it;
1. Configure a custom _Dimension_ and a _Metric_ for a _Tag_ visit and its engagement value to support a custom report on Taxonomy performance (all configuration items are enclosed as Sitecore packages):
  - in **Master** DB via the _Marketing Control Panel_
    - `/sitecore/system/Marketing Control Panel/Experience Analytics/Dimensions/Visits/By taxonomy`
    - `/sitecore/system/Marketing Control Panel/Experience Analytics/Dimensions/Visits/By taxonomy/All visits by taxonomy`
  - in **Core** DB
    - `/sitecore/client/Applications/ExperienceAnalytics/Common/System/ChartFields/FlexibleMetrics/Engagement value`
10. Configure the _RegisterTaxonomyPageEvent_ pipeline by copying `..\TaxonomyReporting\App_Config\Include\TaxonomyReporting.config` into your final `\App_Config\Include\` folder;
11. Deploy _Page Events_ and _Segments_ via _Control Panel -> Deploy marketing definitions_
<img src="https://github.com/kate-orlova/taxonomy-in-sitecore/raw/master/assets/deploy%20marketing%20definitions%20modal%20window.jpg" alt="Deploy marketing definitions" width="400" />
12. Enjoy!

# Contribution
Hope you found this module useful, your contributions and suggestions will be very much appreciated. Please submit a pull request.

# License
The Taxonomy in Sitecore module is released under the MIT license what means that you can modify and use it how you want even for commercial use. Please give it a star if you like it and your experience was positive.
