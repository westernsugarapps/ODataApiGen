//#region ODataApi Imports
{% for import in Imports %}import { {{import.Names | join: ", "}} } from '{{import.Path}}';
{% endfor %}//#endregion

export const ISFLAGS_{{Name | upcase}} = {{Flags}};
export enum {{Name}} {
  //#region ODataApi Members
  {% for member in Members %}{{member}},
  {% endfor %}//#endregion
}
