<template>

<b-container class="pt-4">
	<b-media class="pr-2">
		<img slot="aside" :src="product.thumbnail" :alt="product.name" />
		<h3 class="mb-1">{{ product.name }}</h3>
		<p class="mt-2 mb-4">
			{{ product.shortDescription }}
		</p>
		<p class="mt-4 mb-4">
			$ {{ product.price }}
		</p>
		<b-button variant="primary" class="mb-3">Add to cart</b-button>
	</b-media>

	<h3 class="mt-4 mb-1">Product details</h3>
	<p class="mt-2 mb-4">
		{{ product.description }}
	</p>
</b-container>

</template>

<script>
export default {
	name: "product-details",
	props: {
		product: {
			type: Object,
			required: true
		}
	}
};
</script>

<style>
.details {
	padding: 20px;
}

</style>
