<template>
	<b-modal ref="modal" id="variantModal" title="Add a new variant" ok-title="Add" @ok="submit">
		<form @submit.prevent="submit">
		<typeahead
			label="Color"
			name="color" 
			:items="colors" 
			v-validate="'required|min:3'" 
			:error="errors.first('color')" 
			v-model="color" />

		<typeahead
			label="Capacity"
			name="capacity" 
			:items="storage" 
			v-validate="'required|min:3'" 
			:error="errors.first('capacity')"
			v-model="capacity" />

		<form-input
			type="number"
			label="Price"
			name="price"
			:error="errors.first('price')"
			prepend="$"
			v-model="price"
			v-validate="'required|decimal'" /> 
		</form>
	</b-modal>
</template>

<script>
	import FormInput from "../shared/FormInput.vue";
	import Typeahead from "../shared/Typeahead.vue";

	export default {
	name: "add-variant-modal",
	components: {
		FormInput,
		Typeahead
	},
	props: {
		colors: {
			type: Array
		},
		storage: {
			type: Array
		}
	},
	data() {
		return {
			color: "",
			capacity: "",
			price: ""
		};
	},
	methods: {
		submit() {
			this.$validator.validateAll().then(result => {
				if (result) {
					const payload = {
						color: this.color,
						storage: this.capacity,
						price: this.price
					};

					this.$emit("submit", payload);
					this.$refs.modal.hide();
					this.color = "";
					this.capacity = "";
					this.price = "";
				}
			});
		}
	}
};
</script>

