<template>
  <form-input-base :label="label" data-ting="bryan"> 
	
		<!-- inheriting component content goes here... -->
		<div class="input-group">
			<div v-if="prepend" class="input-group-prepend">
				<span class="input-group-text">{{ prepend }}</span>
			</div>

			<input
				:class="classes"
				:type="type"
				:name="name" 
				:value="value"
				@focus="$emit('focus')"
				@blur="$emit('blur')"
				@input="$emit('input', $event.target.value)"
				@change="$emit('change', $event.target.value)" />

			<div v-if="append" class="input-group-append">
				<span class="input-group-text">{{ append }}</span>
			</div> 

			<div v-if="error" class="invalid-feedback">
				{{ error }}
			</div>
		</div>

  </form-input-base>
</template>

<script>
/* This is a workaround for the fact that templates aren't inherited by 
subcomponents that extend a base component. Instead, declare the base 
component as a child of the subcomponent, then render it as part of the template.
This only works because we included a slot component as part of the base 
component's own template */

import FormInputBase from "./FormInputBase.vue";

export default {
	name: "form-input",
	extends: FormInputBase,
	components: {
		FormInputBase
	},
	props: {
		type: {
			type: String,
			default: "text"
		},
		prepend: {
			type: String
		},
		append: {
			type: String
		}

	}
}
</script>
