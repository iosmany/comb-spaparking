import{$a as O,Ca as ee,Ha as te,J as v,L as B,Ma as N,N as p,Ua as V,V as Q,Y as w,Ya as ne,_a as ie,a as l,aa as I,ab as f,b as u,bb as H,ea as y,g as X,j as Y,o as K,oa as o,qa as C,sa as S,t as J,wa as U,xa as d,ya as h}from"./chunk-L26F2MYK.js";var he=(()=>{class n{_renderer;_elementRef;onChange=t=>{};onTouched=()=>{};constructor(t,i){this._renderer=t,this._elementRef=i}setProperty(t,i){this._renderer.setProperty(this._elementRef.nativeElement,t,i)}registerOnTouched(t){this.onTouched=t}registerOnChange(t){this.onChange=t}setDisabledState(t){this.setProperty("disabled",t)}static \u0275fac=function(i){return new(i||n)(o(C),o(y))};static \u0275dir=d({type:n})}return n})(),z=(()=>{class n extends he{static \u0275fac=(()=>{let t;return function(r){return(t||(t=w(n)))(r||n)}})();static \u0275dir=d({type:n,features:[h]})}return n})(),R=new p("");var Ee={provide:R,useExisting:v(()=>fe),multi:!0};function Fe(){let n=H()?H().getUserAgent():"";return/android (\d+)/.test(n.toLowerCase())}var we=new p(""),fe=(()=>{class n extends he{_compositionMode;_composing=!1;constructor(t,i,r){super(t,i),this._compositionMode=r,this._compositionMode==null&&(this._compositionMode=!Fe())}writeValue(t){let i=t??"";this.setProperty("value",i)}_handleInput(t){(!this._compositionMode||this._compositionMode&&!this._composing)&&this.onChange(t)}_compositionStart(){this._composing=!0}_compositionEnd(t){this._composing=!1,this._compositionMode&&this.onChange(t)}static \u0275fac=function(i){return new(i||n)(o(C),o(y),o(we,8))};static \u0275dir=d({type:n,selectors:[["input","formControlName","",3,"type","checkbox"],["textarea","formControlName",""],["input","formControl","",3,"type","checkbox"],["textarea","formControl",""],["input","ngModel","",3,"type","checkbox"],["textarea","ngModel",""],["","ngDefaultControl",""]],hostBindings:function(i,r){i&1&&N("input",function(a){return r._handleInput(a.target.value)})("blur",function(){return r.onTouched()})("compositionstart",function(){return r._compositionStart()})("compositionend",function(a){return r._compositionEnd(a.target.value)})},standalone:!1,features:[V([Ee]),h]})}return n})();var Ie=new p(""),Se=new p("");function pe(n){return n!=null}function ge(n){return ee(n)?Y(n):n}function me(n){let e={};return n.forEach(t=>{e=t!=null?l(l({},e),t):e}),Object.keys(e).length===0?null:e}function _e(n,e){return e.map(t=>t(n))}function Ne(n){return!n.validate}function ve(n){return n.map(e=>Ne(e)?e:t=>e.validate(t))}function Oe(n){if(!n)return null;let e=n.filter(pe);return e.length==0?null:function(t){return me(_e(t,e))}}function ye(n){return n!=null?Oe(ve(n)):null}function xe(n){if(!n)return null;let e=n.filter(pe);return e.length==0?null:function(t){let i=_e(t,e).map(ge);return J(i).pipe(K(me))}}function Ce(n){return n!=null?xe(ve(n)):null}function re(n,e){return n===null?[e]:Array.isArray(n)?[...n,e]:[n,e]}function Pe(n){return n._rawValidators}function ke(n){return n._rawAsyncValidators}function L(n){return n?Array.isArray(n)?n:[n]:[]}function P(n,e){return Array.isArray(n)?n.includes(e):n===e}function se(n,e){let t=L(e);return L(n).forEach(r=>{P(t,r)||t.push(r)}),t}function oe(n,e){return L(e).filter(t=>!P(n,t))}var k=class{get value(){return this.control?this.control.value:null}get valid(){return this.control?this.control.valid:null}get invalid(){return this.control?this.control.invalid:null}get pending(){return this.control?this.control.pending:null}get disabled(){return this.control?this.control.disabled:null}get enabled(){return this.control?this.control.enabled:null}get errors(){return this.control?this.control.errors:null}get pristine(){return this.control?this.control.pristine:null}get dirty(){return this.control?this.control.dirty:null}get touched(){return this.control?this.control.touched:null}get status(){return this.control?this.control.status:null}get untouched(){return this.control?this.control.untouched:null}get statusChanges(){return this.control?this.control.statusChanges:null}get valueChanges(){return this.control?this.control.valueChanges:null}get path(){return null}_composedValidatorFn;_composedAsyncValidatorFn;_rawValidators=[];_rawAsyncValidators=[];_setValidators(e){this._rawValidators=e||[],this._composedValidatorFn=ye(this._rawValidators)}_setAsyncValidators(e){this._rawAsyncValidators=e||[],this._composedAsyncValidatorFn=Ce(this._rawAsyncValidators)}get validator(){return this._composedValidatorFn||null}get asyncValidator(){return this._composedAsyncValidatorFn||null}_onDestroyCallbacks=[];_registerOnDestroy(e){this._onDestroyCallbacks.push(e)}_invokeOnDestroyCallbacks(){this._onDestroyCallbacks.forEach(e=>e()),this._onDestroyCallbacks=[]}reset(e=void 0){this.control&&this.control.reset(e)}hasError(e,t){return this.control?this.control.hasError(e,t):!1}getError(e,t){return this.control?this.control.getError(e,t):null}},$=class extends k{name;get formDirective(){return null}get path(){return null}},E=class extends k{_parent=null;name=null;valueAccessor=null},W=class{_cd;constructor(e){this._cd=e}get isTouched(){return this._cd?.control?._touched?.(),!!this._cd?.control?.touched}get isUntouched(){return!!this._cd?.control?.untouched}get isPristine(){return this._cd?.control?._pristine?.(),!!this._cd?.control?.pristine}get isDirty(){return!!this._cd?.control?.dirty}get isValid(){return this._cd?.control?._status?.(),!!this._cd?.control?.valid}get isInvalid(){return!!this._cd?.control?.invalid}get isPending(){return!!this._cd?.control?.pending}get isSubmitted(){return this._cd?._submitted?.(),!!this._cd?.submitted}},Ge={"[class.ng-untouched]":"isUntouched","[class.ng-touched]":"isTouched","[class.ng-pristine]":"isPristine","[class.ng-dirty]":"isDirty","[class.ng-valid]":"isValid","[class.ng-invalid]":"isInvalid","[class.ng-pending]":"isPending"},Ft=u(l({},Ge),{"[class.ng-submitted]":"isSubmitted"}),wt=(()=>{class n extends W{constructor(t){super(t)}static \u0275fac=function(i){return new(i||n)(o(E,2))};static \u0275dir=d({type:n,selectors:[["","formControlName",""],["","ngModel",""],["","formControl",""]],hostVars:14,hostBindings:function(i,r){i&2&&te("ng-untouched",r.isUntouched)("ng-touched",r.isTouched)("ng-pristine",r.isPristine)("ng-dirty",r.isDirty)("ng-valid",r.isValid)("ng-invalid",r.isInvalid)("ng-pending",r.isPending)},standalone:!1,features:[h]})}return n})();var D="VALID",x="INVALID",g="PENDING",b="DISABLED",_=class{},G=class extends _{value;source;constructor(e,t){super(),this.value=e,this.source=t}},A=class extends _{pristine;source;constructor(e,t){super(),this.pristine=e,this.source=t}},M=class extends _{touched;source;constructor(e,t){super(),this.touched=e,this.source=t}},m=class extends _{status;source;constructor(e,t){super(),this.status=e,this.source=t}};function Re(n){return(T(n)?n.validators:n)||null}function Te(n){return Array.isArray(n)?ye(n):n||null}function je(n,e){return(T(e)?e.asyncValidators:n)||null}function Be(n){return Array.isArray(n)?Ce(n):n||null}function T(n){return n!=null&&!Array.isArray(n)&&typeof n=="object"}var q=class{_pendingDirty=!1;_hasOwnPendingAsyncValidator=null;_pendingTouched=!1;_onCollectionChange=()=>{};_updateOn;_parent=null;_asyncValidationSubscription;_composedValidatorFn;_composedAsyncValidatorFn;_rawValidators;_rawAsyncValidators;value;constructor(e,t){this._assignValidators(e),this._assignAsyncValidators(t)}get validator(){return this._composedValidatorFn}set validator(e){this._rawValidators=this._composedValidatorFn=e}get asyncValidator(){return this._composedAsyncValidatorFn}set asyncValidator(e){this._rawAsyncValidators=this._composedAsyncValidatorFn=e}get parent(){return this._parent}get status(){return f(this.statusReactive)}set status(e){f(()=>this.statusReactive.set(e))}_status=O(()=>this.statusReactive());statusReactive=S(void 0);get valid(){return this.status===D}get invalid(){return this.status===x}get pending(){return this.status==g}get disabled(){return this.status===b}get enabled(){return this.status!==b}errors;get pristine(){return f(this.pristineReactive)}set pristine(e){f(()=>this.pristineReactive.set(e))}_pristine=O(()=>this.pristineReactive());pristineReactive=S(!0);get dirty(){return!this.pristine}get touched(){return f(this.touchedReactive)}set touched(e){f(()=>this.touchedReactive.set(e))}_touched=O(()=>this.touchedReactive());touchedReactive=S(!1);get untouched(){return!this.touched}_events=new X;events=this._events.asObservable();valueChanges;statusChanges;get updateOn(){return this._updateOn?this._updateOn:this.parent?this.parent.updateOn:"change"}setValidators(e){this._assignValidators(e)}setAsyncValidators(e){this._assignAsyncValidators(e)}addValidators(e){this.setValidators(se(e,this._rawValidators))}addAsyncValidators(e){this.setAsyncValidators(se(e,this._rawAsyncValidators))}removeValidators(e){this.setValidators(oe(e,this._rawValidators))}removeAsyncValidators(e){this.setAsyncValidators(oe(e,this._rawAsyncValidators))}hasValidator(e){return P(this._rawValidators,e)}hasAsyncValidator(e){return P(this._rawAsyncValidators,e)}clearValidators(){this.validator=null}clearAsyncValidators(){this.asyncValidator=null}markAsTouched(e={}){let t=this.touched===!1;this.touched=!0;let i=e.sourceControl??this;this._parent&&!e.onlySelf&&this._parent.markAsTouched(u(l({},e),{sourceControl:i})),t&&e.emitEvent!==!1&&this._events.next(new M(!0,i))}markAllAsTouched(e={}){this.markAsTouched({onlySelf:!0,emitEvent:e.emitEvent,sourceControl:this}),this._forEachChild(t=>t.markAllAsTouched(e))}markAsUntouched(e={}){let t=this.touched===!0;this.touched=!1,this._pendingTouched=!1;let i=e.sourceControl??this;this._forEachChild(r=>{r.markAsUntouched({onlySelf:!0,emitEvent:e.emitEvent,sourceControl:i})}),this._parent&&!e.onlySelf&&this._parent._updateTouched(e,i),t&&e.emitEvent!==!1&&this._events.next(new M(!1,i))}markAsDirty(e={}){let t=this.pristine===!0;this.pristine=!1;let i=e.sourceControl??this;this._parent&&!e.onlySelf&&this._parent.markAsDirty(u(l({},e),{sourceControl:i})),t&&e.emitEvent!==!1&&this._events.next(new A(!1,i))}markAsPristine(e={}){let t=this.pristine===!1;this.pristine=!0,this._pendingDirty=!1;let i=e.sourceControl??this;this._forEachChild(r=>{r.markAsPristine({onlySelf:!0,emitEvent:e.emitEvent})}),this._parent&&!e.onlySelf&&this._parent._updatePristine(e,i),t&&e.emitEvent!==!1&&this._events.next(new A(!0,i))}markAsPending(e={}){this.status=g;let t=e.sourceControl??this;e.emitEvent!==!1&&(this._events.next(new m(this.status,t)),this.statusChanges.emit(this.status)),this._parent&&!e.onlySelf&&this._parent.markAsPending(u(l({},e),{sourceControl:t}))}disable(e={}){let t=this._parentMarkedDirty(e.onlySelf);this.status=b,this.errors=null,this._forEachChild(r=>{r.disable(u(l({},e),{onlySelf:!0}))}),this._updateValue();let i=e.sourceControl??this;e.emitEvent!==!1&&(this._events.next(new G(this.value,i)),this._events.next(new m(this.status,i)),this.valueChanges.emit(this.value),this.statusChanges.emit(this.status)),this._updateAncestors(u(l({},e),{skipPristineCheck:t}),this),this._onDisabledChange.forEach(r=>r(!0))}enable(e={}){let t=this._parentMarkedDirty(e.onlySelf);this.status=D,this._forEachChild(i=>{i.enable(u(l({},e),{onlySelf:!0}))}),this.updateValueAndValidity({onlySelf:!0,emitEvent:e.emitEvent}),this._updateAncestors(u(l({},e),{skipPristineCheck:t}),this),this._onDisabledChange.forEach(i=>i(!1))}_updateAncestors(e,t){this._parent&&!e.onlySelf&&(this._parent.updateValueAndValidity(e),e.skipPristineCheck||this._parent._updatePristine({},t),this._parent._updateTouched({},t))}setParent(e){this._parent=e}getRawValue(){return this.value}updateValueAndValidity(e={}){if(this._setInitialStatus(),this._updateValue(),this.enabled){let i=this._cancelExistingSubscription();this.errors=this._runValidator(),this.status=this._calculateStatus(),(this.status===D||this.status===g)&&this._runAsyncValidator(i,e.emitEvent)}let t=e.sourceControl??this;e.emitEvent!==!1&&(this._events.next(new G(this.value,t)),this._events.next(new m(this.status,t)),this.valueChanges.emit(this.value),this.statusChanges.emit(this.status)),this._parent&&!e.onlySelf&&this._parent.updateValueAndValidity(u(l({},e),{sourceControl:t}))}_updateTreeValidity(e={emitEvent:!0}){this._forEachChild(t=>t._updateTreeValidity(e)),this.updateValueAndValidity({onlySelf:!0,emitEvent:e.emitEvent})}_setInitialStatus(){this.status=this._allControlsDisabled()?b:D}_runValidator(){return this.validator?this.validator(this):null}_runAsyncValidator(e,t){if(this.asyncValidator){this.status=g,this._hasOwnPendingAsyncValidator={emitEvent:t!==!1};let i=ge(this.asyncValidator(this));this._asyncValidationSubscription=i.subscribe(r=>{this._hasOwnPendingAsyncValidator=null,this.setErrors(r,{emitEvent:t,shouldHaveEmitted:e})})}}_cancelExistingSubscription(){if(this._asyncValidationSubscription){this._asyncValidationSubscription.unsubscribe();let e=this._hasOwnPendingAsyncValidator?.emitEvent??!1;return this._hasOwnPendingAsyncValidator=null,e}return!1}setErrors(e,t={}){this.errors=e,this._updateControlsErrors(t.emitEvent!==!1,this,t.shouldHaveEmitted)}get(e){let t=e;return t==null||(Array.isArray(t)||(t=t.split(".")),t.length===0)?null:t.reduce((i,r)=>i&&i._find(r),this)}getError(e,t){let i=t?this.get(t):this;return i&&i.errors?i.errors[e]:null}hasError(e,t){return!!this.getError(e,t)}get root(){let e=this;for(;e._parent;)e=e._parent;return e}_updateControlsErrors(e,t,i){this.status=this._calculateStatus(),e&&this.statusChanges.emit(this.status),(e||i)&&this._events.next(new m(this.status,t)),this._parent&&this._parent._updateControlsErrors(e,t,i)}_initObservables(){this.valueChanges=new I,this.statusChanges=new I}_calculateStatus(){return this._allControlsDisabled()?b:this.errors?x:this._hasOwnPendingAsyncValidator||this._anyControlsHaveStatus(g)?g:this._anyControlsHaveStatus(x)?x:D}_anyControlsHaveStatus(e){return this._anyControls(t=>t.status===e)}_anyControlsDirty(){return this._anyControls(e=>e.dirty)}_anyControlsTouched(){return this._anyControls(e=>e.touched)}_updatePristine(e,t){let i=!this._anyControlsDirty(),r=this.pristine!==i;this.pristine=i,this._parent&&!e.onlySelf&&this._parent._updatePristine(e,t),r&&this._events.next(new A(this.pristine,t))}_updateTouched(e={},t){this.touched=this._anyControlsTouched(),this._events.next(new M(this.touched,t)),this._parent&&!e.onlySelf&&this._parent._updateTouched(e,t)}_onDisabledChange=[];_registerOnCollectionChange(e){this._onCollectionChange=e}_setUpdateStrategy(e){T(e)&&e.updateOn!=null&&(this._updateOn=e.updateOn)}_parentMarkedDirty(e){let t=this._parent&&this._parent.dirty;return!e&&!!t&&!this._parent._anyControlsDirty()}_find(e){return null}_assignValidators(e){this._rawValidators=Array.isArray(e)?e.slice():e,this._composedValidatorFn=Te(this._rawValidators)}_assignAsyncValidators(e){this._rawAsyncValidators=Array.isArray(e)?e.slice():e,this._composedAsyncValidatorFn=Be(this._rawAsyncValidators)}};var Ve=new p("CallSetDisabledState",{providedIn:"root",factory:()=>Z}),Z="always";function Ue(n,e){return[...e.path,n]}function He(n,e,t=Z){$e(n,e),e.valueAccessor.writeValue(n.value),(n.disabled||t==="always")&&e.valueAccessor.setDisabledState?.(n.disabled),We(n,e),ze(n,e),qe(n,e),Le(n,e)}function ae(n,e){n.forEach(t=>{t.registerOnValidatorChange&&t.registerOnValidatorChange(e)})}function Le(n,e){if(e.valueAccessor.setDisabledState){let t=i=>{e.valueAccessor.setDisabledState(i)};n.registerOnDisabledChange(t),e._registerOnDestroy(()=>{n._unregisterOnDisabledChange(t)})}}function $e(n,e){let t=Pe(n);e.validator!==null?n.setValidators(re(t,e.validator)):typeof t=="function"&&n.setValidators([t]);let i=ke(n);e.asyncValidator!==null?n.setAsyncValidators(re(i,e.asyncValidator)):typeof i=="function"&&n.setAsyncValidators([i]);let r=()=>n.updateValueAndValidity();ae(e._rawValidators,r),ae(e._rawAsyncValidators,r)}function We(n,e){e.valueAccessor.registerOnChange(t=>{n._pendingValue=t,n._pendingChange=!0,n._pendingDirty=!0,n.updateOn==="change"&&De(n,e)})}function qe(n,e){e.valueAccessor.registerOnTouched(()=>{n._pendingTouched=!0,n.updateOn==="blur"&&n._pendingChange&&De(n,e),n.updateOn!=="submit"&&n.markAsTouched()})}function De(n,e){n._pendingDirty&&n.markAsDirty(),n.setValue(n._pendingValue,{emitModelToViewChange:!1}),e.viewToModelUpdate(n._pendingValue),n._pendingChange=!1}function ze(n,e){let t=(i,r)=>{e.valueAccessor.writeValue(i),r&&e.viewToModelUpdate(i)};n.registerOnChange(t),e._registerOnDestroy(()=>{n._unregisterOnChange(t)})}function Ze(n,e){if(!n.hasOwnProperty("model"))return!1;let t=n.model;return t.isFirstChange()?!0:!Object.is(e,t.currentValue)}function Xe(n){return Object.getPrototypeOf(n.constructor)===z}function Ye(n,e){if(!e)return null;Array.isArray(e);let t,i,r;return e.forEach(s=>{s.constructor===fe?t=s:Xe(s)?i=s:r=s}),r||i||t||null}function le(n,e){let t=n.indexOf(e);t>-1&&n.splice(t,1)}function ue(n){return typeof n=="object"&&n!==null&&Object.keys(n).length===2&&"value"in n&&"disabled"in n}var Ke=class extends q{defaultValue=null;_onChange=[];_pendingValue;_pendingChange=!1;constructor(e=null,t,i){super(Re(t),je(i,t)),this._applyFormState(e),this._setUpdateStrategy(t),this._initObservables(),this.updateValueAndValidity({onlySelf:!0,emitEvent:!!this.asyncValidator}),T(t)&&(t.nonNullable||t.initialValueIsDefault)&&(ue(e)?this.defaultValue=e.value:this.defaultValue=e)}setValue(e,t={}){this.value=this._pendingValue=e,this._onChange.length&&t.emitModelToViewChange!==!1&&this._onChange.forEach(i=>i(this.value,t.emitViewToModelChange!==!1)),this.updateValueAndValidity(t)}patchValue(e,t={}){this.setValue(e,t)}reset(e=this.defaultValue,t={}){this._applyFormState(e),this.markAsPristine(t),this.markAsUntouched(t),this.setValue(this.value,t),this._pendingChange=!1}_updateValue(){}_anyControls(e){return!1}_allControlsDisabled(){return this.disabled}registerOnChange(e){this._onChange.push(e)}_unregisterOnChange(e){le(this._onChange,e)}registerOnDisabledChange(e){this._onDisabledChange.push(e)}_unregisterOnDisabledChange(e){le(this._onDisabledChange,e)}_forEachChild(e){}_syncPendingControls(){return this.updateOn==="submit"&&(this._pendingDirty&&this.markAsDirty(),this._pendingTouched&&this.markAsTouched(),this._pendingChange)?(this.setValue(this._pendingValue,{onlySelf:!0,emitModelToViewChange:!1}),!0):!1}_applyFormState(e){ue(e)?(this.value=this._pendingValue=e.value,e.disabled?this.disable({onlySelf:!0,emitEvent:!1}):this.enable({onlySelf:!0,emitEvent:!1})):this.value=this._pendingValue=e}};var Je={provide:E,useExisting:v(()=>Qe)},de=Promise.resolve(),Qe=(()=>{class n extends E{_changeDetectorRef;callSetDisabledState;control=new Ke;static ngAcceptInputType_isDisabled;_registered=!1;viewModel;name="";isDisabled;model;options;update=new I;constructor(t,i,r,s,a,c){super(),this._changeDetectorRef=a,this.callSetDisabledState=c,this._parent=t,this._setValidators(i),this._setAsyncValidators(r),this.valueAccessor=Ye(this,s)}ngOnChanges(t){if(this._checkForErrors(),!this._registered||"name"in t){if(this._registered&&(this._checkName(),this.formDirective)){let i=t.name.previousValue;this.formDirective.removeControl({name:i,path:this._getPath(i)})}this._setUpControl()}"isDisabled"in t&&this._updateDisabled(t),Ze(t,this.viewModel)&&(this._updateValue(this.model),this.viewModel=this.model)}ngOnDestroy(){this.formDirective&&this.formDirective.removeControl(this)}get path(){return this._getPath(this.name)}get formDirective(){return this._parent?this._parent.formDirective:null}viewToModelUpdate(t){this.viewModel=t,this.update.emit(t)}_setUpControl(){this._setUpdateStrategy(),this._isStandalone()?this._setUpStandalone():this.formDirective.addControl(this),this._registered=!0}_setUpdateStrategy(){this.options&&this.options.updateOn!=null&&(this.control._updateOn=this.options.updateOn)}_isStandalone(){return!this._parent||!!(this.options&&this.options.standalone)}_setUpStandalone(){He(this.control,this,this.callSetDisabledState),this.control.updateValueAndValidity({emitEvent:!1})}_checkForErrors(){this._isStandalone()||this._checkParentType(),this._checkName()}_checkParentType(){}_checkName(){this.options&&this.options.name&&(this.name=this.options.name),!this._isStandalone()&&this.name}_updateValue(t){de.then(()=>{this.control.setValue(t,{emitViewToModelChange:!1}),this._changeDetectorRef?.markForCheck()})}_updateDisabled(t){let i=t.isDisabled.currentValue,r=i!==0&&ie(i);de.then(()=>{r&&!this.control.disabled?this.control.disable():!r&&this.control.disabled&&this.control.enable(),this._changeDetectorRef?.markForCheck()})}_getPath(t){return this._parent?Ue(t,this._parent):[t]}static \u0275fac=function(i){return new(i||n)(o($,9),o(Ie,10),o(Se,10),o(R,10),o(ne,8),o(Ve,8))};static \u0275dir=d({type:n,selectors:[["","ngModel","",3,"formControlName","",3,"formControl",""]],inputs:{name:"name",isDisabled:[0,"disabled","isDisabled"],model:[0,"ngModel","model"],options:[0,"ngModelOptions","options"]},outputs:{update:"ngModelChange"},exportAs:["ngModel"],standalone:!1,features:[V([Je]),h,Q]})}return n})();var et={provide:R,useExisting:v(()=>Ae),multi:!0};function be(n,e){return n==null?`${e}`:(e&&typeof e=="object"&&(e="Object"),`${n}: ${e}`.slice(0,50))}function tt(n){return n.split(":")[0]}var Ae=(()=>{class n extends z{value;_optionMap=new Map;_idCounter=0;set compareWith(t){this._compareWith=t}_compareWith=Object.is;writeValue(t){this.value=t;let i=this._getOptionId(t),r=be(i,t);this.setProperty("value",r)}registerOnChange(t){this.onChange=i=>{this.value=this._getOptionValue(i),t(this.value)}}_registerOption(){return(this._idCounter++).toString()}_getOptionId(t){for(let i of this._optionMap.keys())if(this._compareWith(this._optionMap.get(i),t))return i;return null}_getOptionValue(t){let i=tt(t);return this._optionMap.has(i)?this._optionMap.get(i):t}static \u0275fac=(()=>{let t;return function(r){return(t||(t=w(n)))(r||n)}})();static \u0275dir=d({type:n,selectors:[["select","formControlName","",3,"multiple",""],["select","formControl","",3,"multiple",""],["select","ngModel","",3,"multiple",""]],hostBindings:function(i,r){i&1&&N("change",function(a){return r.onChange(a.target.value)})("blur",function(){return r.onTouched()})},inputs:{compareWith:"compareWith"},standalone:!1,features:[V([et]),h]})}return n})(),St=(()=>{class n{_element;_renderer;_select;id;constructor(t,i,r){this._element=t,this._renderer=i,this._select=r,this._select&&(this.id=this._select._registerOption())}set ngValue(t){this._select!=null&&(this._select._optionMap.set(this.id,t),this._setElementValue(be(this.id,t)),this._select.writeValue(this._select.value))}set value(t){this._setElementValue(t),this._select&&this._select.writeValue(this._select.value)}_setElementValue(t){this._renderer.setProperty(this._element.nativeElement,"value",t)}ngOnDestroy(){this._select&&(this._select._optionMap.delete(this.id),this._select.writeValue(this._select.value))}static \u0275fac=function(i){return new(i||n)(o(y),o(C),o(Ae,9))};static \u0275dir=d({type:n,selectors:[["option"]],inputs:{ngValue:"ngValue",value:"value"},standalone:!1})}return n})(),nt={provide:R,useExisting:v(()=>Me),multi:!0};function ce(n,e){return n==null?`${e}`:(typeof e=="string"&&(e=`'${e}'`),e&&typeof e=="object"&&(e="Object"),`${n}: ${e}`.slice(0,50))}function it(n){return n.split(":")[0]}var Me=(()=>{class n extends z{value;_optionMap=new Map;_idCounter=0;set compareWith(t){this._compareWith=t}_compareWith=Object.is;writeValue(t){this.value=t;let i;if(Array.isArray(t)){let r=t.map(s=>this._getOptionId(s));i=(s,a)=>{s._setSelected(r.indexOf(a.toString())>-1)}}else i=(r,s)=>{r._setSelected(!1)};this._optionMap.forEach(i)}registerOnChange(t){this.onChange=i=>{let r=[],s=i.selectedOptions;if(s!==void 0){let a=s;for(let c=0;c<a.length;c++){let F=a[c],j=this._getOptionValue(F.value);r.push(j)}}else{let a=i.options;for(let c=0;c<a.length;c++){let F=a[c];if(F.selected){let j=this._getOptionValue(F.value);r.push(j)}}}this.value=r,t(r)}}_registerOption(t){let i=(this._idCounter++).toString();return this._optionMap.set(i,t),i}_getOptionId(t){for(let i of this._optionMap.keys())if(this._compareWith(this._optionMap.get(i)._value,t))return i;return null}_getOptionValue(t){let i=it(t);return this._optionMap.has(i)?this._optionMap.get(i)._value:t}static \u0275fac=(()=>{let t;return function(r){return(t||(t=w(n)))(r||n)}})();static \u0275dir=d({type:n,selectors:[["select","multiple","","formControlName",""],["select","multiple","","formControl",""],["select","multiple","","ngModel",""]],hostBindings:function(i,r){i&1&&N("change",function(a){return r.onChange(a.target)})("blur",function(){return r.onTouched()})},inputs:{compareWith:"compareWith"},standalone:!1,features:[V([nt]),h]})}return n})(),Nt=(()=>{class n{_element;_renderer;_select;id;_value;constructor(t,i,r){this._element=t,this._renderer=i,this._select=r,this._select&&(this.id=this._select._registerOption(this))}set ngValue(t){this._select!=null&&(this._value=t,this._setElementValue(ce(this.id,t)),this._select.writeValue(this._select.value))}set value(t){this._select?(this._value=t,this._setElementValue(ce(this.id,t)),this._select.writeValue(this._select.value)):this._setElementValue(t)}_setElementValue(t){this._renderer.setProperty(this._element.nativeElement,"value",t)}_setSelected(t){this._renderer.setProperty(this._element.nativeElement,"selected",t)}ngOnDestroy(){this._select&&(this._select._optionMap.delete(this.id),this._select.writeValue(this._select.value))}static \u0275fac=function(i){return new(i||n)(o(y),o(C),o(Me,9))};static \u0275dir=d({type:n,selectors:[["option"]],inputs:{ngValue:"ngValue",value:"value"},standalone:!1})}return n})();var rt=(()=>{class n{static \u0275fac=function(i){return new(i||n)};static \u0275mod=U({type:n});static \u0275inj=B({})}return n})();var Ot=(()=>{class n{static withConfig(t){return{ngModule:n,providers:[{provide:Ve,useValue:t.callSetDisabledState??Z}]}}static \u0275fac=function(i){return new(i||n)};static \u0275mod=U({type:n});static \u0275inj=B({imports:[rt]})}return n})();export{fe as a,wt as b,Qe as c,Ae as d,St as e,Nt as f,Ot as g};
