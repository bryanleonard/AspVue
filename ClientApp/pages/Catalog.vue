<template>
	<product-list :products="products" />
</template>

<script>
import ProductList from '../components/catalog/ProductList.vue'

export default {
	name: 'catalog',
	components : {
		ProductList
	},
	data() {
		return {
			products: []
		};
	},
	mounted() {
		fetch("api/products")
			.then(response => { return response.json() })
			.then(products => { this.products = products });
	}
}
</script>