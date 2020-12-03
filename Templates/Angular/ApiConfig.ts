import { ApiConfig, EDM_PARSERS } from 'angular-odata';

//#region ODataApi Imports
{% for import in Imports %}import { {{import.Names | join: ", "}} } from '{{import.Path}}';
{% endfor %}//#endregion

export const {{Name}} = {
  name: '{{Package.Name}}',
  serviceRootUrl: '{{Package.ServiceRootUrl}}',
  version: '{{Package.Version}}',
  creation: new Date('{{Package.Creation | date: "o"}}'),
  schemas: [
    {% for schema in Package.Schemas %}{{schema.Name}}{% unless forloop.last %},
    {% endunless %}{% endfor %}
  ],
  parsers: EDM_PARSERS
} as ApiConfig;