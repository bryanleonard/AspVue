<template>

<div class="products">
	<b-container>
		<h1 class="mt-4 mb-4">Products</h1>
		<b-row>
			<b-col class="mb-4" sm="6" v-for="product in products" :key="product.id">
				<b-media class="product pr-2">
					<img slot="aside" :src="product.thumbnail" :alt="product.name" @click="view(product)" />
					<h3 class="mt-2" @click="view(product)">
						{{ product.name }}
					</h3>
					<p class="mt-4 mb-4">
						{{ product.shortDescription }}
					</p>
					<p class="mt-4 mb-4">
						Prices from {{ product.price | currency }}
					</p>
				</b-media>
			</b-col>
		</b-row>
	</b-container>
</div>

</template>

<script>


export default {
	name: "product-list",
	props: {
		products: {
			type: Array,
			required: true
		}
	},
	methods: {
		view(product) {
			this.$router.push(`/products/${product.slug}`);
		}
	}
};
</script>

<style lang="scss">

.product {
	
	border: 3px solid #eee;

	img,
	h2,
	h3 {
		cursor: pointer;
	}

	h3 {
		color: #007bff;

		&:hover {
			color: #0069d9;
		}
	}

	img {
		transition: all 0.2s ease-in-out;

		&:hover {
			opacity: .65;
		}
	}
}

</style>
