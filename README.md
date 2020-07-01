[![GitHub license](https://img.shields.io/github/license/kate-orlova/taxonomy-in-sitecore.svg)](https://github.com/kate-orlova/taxonomy-in-sitecore/blob/master/LICENSE)
![GitHub language count](https://img.shields.io/github/languages/count/kate-orlova/taxonomy-in-sitecore.svg?style=flat)
![GitHub top language](https://img.shields.io/github/languages/top/kate-orlova/taxonomy-in-sitecore.svg?style=flat)
![GitHub repo size](https://img.shields.io/github/repo-size/kate-orlova/taxonomy-in-sitecore.svg?style=flat)
![GitHub contributors](https://img.shields.io/github/contributors/kate-orlova/taxonomy-in-sitecore)
![GitHub commit activity](https://img.shields.io/github/commit-activity/y/kate-orlova/taxonomy-in-sitecore)

# Taxonomy in Sitecore
Taxonomy in Sitecore module aims to support your marketing strategy and provide a consistent way of organising your content in Sitecore.

Once the taxonomy tags are defined, you can easily classify your Sitecore Content Items by assigning the appropriate tags and start creating personalisation rules based on them. This will empower you to serve the relevant content for the target audience(s) while using Sitecore Experience Analytics to measure traffic, engagement value and outcomes.

As soon as this is all setup, you can get more insights on how visitors are interacting with your website and its content. This is very important for your marketing strategy as you continue to learn and adjust this over time in accordance with the continual cycle: _test, learn, adjust and re-test_. 

## Flexible settings
Taxonomy field name can be specified in a config file.

## Taxonomy definition
The module ships the following **Taxonomy** defined around the programming languages and their types & classifications:

- Programming Language
     - Programming Language Type
     - Programming Classification

_Taxonomy tags TBC_

## Taxonomy Profiles
Continuing the programming topic, **Sitecore Profiles**, presented in the module, are aligned with the Programming Classifications and implemented on the example of the next IT Professionals:
- Back-End Developer
- Front-End developer
- Full Stack Developer


### Ease of management
TBC

### Pipelines
_ProcessTaxonomyProfiles_ custom pipeline hooks into _Sitecore.Analytics.Pipelines.ProcessItem.ProcessItemProcessor_ pipeline to dynamically assign the relevant Profile Cards to the context item based on the linked tags to it.

The genius of this approach is that you no longer need to assign the required Profile Cards to each Content Item individually. Instead, you just need to link them to your **Taxonomy** tags and then they will be inherited automatically via tags. As a result it will save you from the duplication of work and bring more efficiency to your content classification.

## Sitecore Packages
Sitecore packages contain:

1. **Data Templates**
   - Programming Classification
   - Programming Language
   - Programming Language Type
2. **Tags**
   - Programming Classifications
   - Programming Language Types
   - Programming Languages
3. **Profiles**
   - Profile Keys
   - Profile Cards
   - Pattern Cards

# Contribution
Hope you found this module useful, your contributions and suggestions will be very much appreciated. Please submit a pull request.

# License
The Taxonomy in Sitecore module is released under the MIT license what means that you can modify and use it how you want even for commercial use. Please give it a star if you like it and your experience was positive.
